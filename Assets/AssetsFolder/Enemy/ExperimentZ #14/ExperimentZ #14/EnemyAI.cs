using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;             // ตำแหน่งของผู้เล่น
    public float moveSpeed = 3f;         // ความเร็วการเคลื่อนไหวของศัตรู
    public float attackRange = 1.5f;     // ระยะที่สามารถโจมตีผู้เล่นได้
    public float stoppingDistance = 0.5f; // ระยะที่ศัตรูหยุดเดินเมื่อใกล้ผู้เล่น
    public float attackCooldown = 1f;   // เวลาคูลดาวน์ระหว่างการโจมตีแต่ละครั้ง

    private Animator animator;           // ตัวแปร Animator
    private float attackTimer = 0f;      // ตัวจับเวลาโจมตี
    private bool isAttacking = false;    // เช็คว่ากำลังโจมตีหรือไม่

    void Start()
    {
        animator = GetComponent<Animator>(); // เข้าถึง Animator ของ GameObject
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > attackRange) // ศัตรูอยู่ไกลเกินระยะโจมตี
        {
            MoveTowardsPlayer();
        }
        else // ศัตรูอยู่ในระยะโจมตี
        {
            if (!isAttacking && attackTimer <= 0f)
            {
                StartAttack();
            }
        }

        // ลดเวลา Cooldown ของการโจมตี
        if (attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
        }
    }

    void MoveTowardsPlayer()
    {
        if (isAttacking) return; // ถ้ากำลังโจมตีจะไม่เคลื่อนที่

        Vector2 direction = (player.position - transform.position).normalized; // คำนวณทิศทาง
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime; // เคลื่อนที่

        // เปิดอนิเมชันเดิน
        animator.SetBool("isWalking", true);
        animator.SetBool("isAttacking", false);
    }

    void StartAttack()
    {
        isAttacking = true; // เริ่มโจมตี
        attackTimer = attackCooldown; // ตั้งค่าเวลาคูลดาวน์

        // เปิดอนิเมชันโจมตี
        animator.SetBool("isWalking", false);
        animator.SetBool("isAttacking", true);

        Debug.Log("Enemy attacks!");
        // เรียกใช้ฟังก์ชันทำความเสียหาย
        Invoke(nameof(DealDamage), 0.5f); // เพิ่มเวลาหน่วงให้ตรงกับอนิเมชัน
    }

    void StopAttack()
    {
        isAttacking = false; // หยุดโจมตี
        animator.SetBool("isAttacking", false); // ปิดอนิเมชันโจมตี
    }

    void DealDamage()
    {
        // เพิ่มการทำความเสียหาย (เช็คว่าผู้เล่นยังอยู่ในระยะ)
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // สร้างความเสียหาย 10 หน่วย
                Debug.Log("Player took damage!");
            }
        }

        StopAttack(); // หยุดโจมตีหลังสร้างความเสียหาย
    }
}
