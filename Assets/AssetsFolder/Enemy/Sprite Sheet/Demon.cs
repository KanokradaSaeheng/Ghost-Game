using UnityEngine;

public class Demon : MonoBehaviour
{
    public Transform player;             // อ้างอิงตำแหน่งของผู้เล่น
    public float moveSpeed = 3f;         // ความเร็วในการเคลื่อนที่ของมอนสเตอร์
    public float stoppingDistance = 1f;  // ระยะห่างที่มอนสเตอร์จะหยุดตามผู้เล่น

    private Animator animator;           // ตัวแปรสำหรับ Animator

    private void Start()
    {
        animator = GetComponent<Animator>(); // เข้าถึง Animator ของมอนสเตอร์
    }

    private void Update()
    {
        if (player == null) return; // ถ้าไม่ได้กำหนดผู้เล่น ให้ return

        float distance = Vector3.Distance(transform.position, player.position);

        // ตรวจสอบว่ามอนสเตอร์ควรจะตามผู้เล่นหรือไม่
        if (distance > stoppingDistance)
        {
            // คำนวณทิศทางไปหาผู้เล่น
            Vector3 direction = (player.position - transform.position).normalized;

            // เคลื่อนที่มอนสเตอร์ในทิศทางนั้น
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // เปิดใช้งานอนิเมชั่น Running
            animator.SetBool("Running", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            // หยุดการเคลื่อนไหวและเปลี่ยนเป็นอนิเมชั่น Idle
            animator.SetBool("Running", false);
            animator.SetBool("Idle", true);
        }
    }
}
