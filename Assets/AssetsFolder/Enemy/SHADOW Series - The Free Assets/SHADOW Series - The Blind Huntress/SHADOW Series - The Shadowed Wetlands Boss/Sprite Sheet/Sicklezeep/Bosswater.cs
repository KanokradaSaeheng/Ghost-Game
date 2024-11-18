using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public Transform player;          // ตัวแปรตำแหน่งของผู้เล่น
    public float followRange = 5f;    // ระยะที่มอนสเตอร์จะเริ่มเดินตามผู้เล่น
    public float attackRange = 1f;    // ระยะที่มอนสเตอร์จะเริ่มโจมตีผู้เล่น
    public float speed = 2f;          // ความเร็วของมอนสเตอร์
    private bool isFollowing = false; // สถานะว่ามอนสเตอร์กำลังเดินตามผู้เล่นอยู่หรือไม่
    private bool isAttacking = false; // สถานะว่ามอนสเตอร์กำลังโจมตีอยู่หรือไม่

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            // ถ้าผู้เล่นอยู่ในระยะโจมตี ให้เริ่มโจมตี
            AttackPlayer();
        }
        else if (distanceToPlayer <= followRange)
        {
            // ถ้าผู้เล่นอยู่ในระยะเดินตาม แต่ไม่ได้อยู่ในระยะโจมตี ให้เดินตามผู้เล่น
            FollowPlayer();
        }
        else
        {
            // ถ้าอยู่นอกระยะเดินตาม หยุดเดินตาม
            StopFollowing();
        }
    }

    void FollowPlayer()
    {
        if (!isFollowing)
        {
            isFollowing = true;
            Debug.Log("มอนสเตอร์เริ่มเดินตามผู้เล่น");
        }

        // คำนวณทิศทางเข้าหาผู้เล่น
        Vector2 direction = (player.position - transform.position).normalized;

        // เคลื่อนที่ไปยังตำแหน่งของผู้เล่น
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        // หยุดการโจมตีถ้ากำลังเดินตาม
        isAttacking = false;
    }

    void StopFollowing()
    {
        if (isFollowing)
        {
            isFollowing = false;
            Debug.Log("มอนสเตอร์หยุดเดินตามผู้เล่น");
        }
    }

    void AttackPlayer()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            Debug.Log("มอนสเตอร์กำลังโจมตีผู้เล่น!");

            // โค้ดโจมตีผู้เล่นเพิ่มเติมได้ที่นี่ เช่น ลด HP ของผู้เล่น
        }
    }
}
