using UnityEngine;
using UnityEngine.AI;

public class Bosssnake : MonoBehaviour
{
    public Transform player; // ตัวแปรสำหรับตำแหน่งผู้เล่น
    public float followRange = 10f; // ระยะทางที่มอนสเตอร์จะเริ่มเดินตาม
    public float stopRange = 2f; // ระยะทางที่มอนสเตอร์จะหยุดเมื่อเข้าใกล้ผู้เล่น
    private Animator animator; // ตัวแปรสำหรับ Animator
    private NavMeshAgent agent; // ตัวแปรสำหรับ NavMeshAgent

    void Start()
    {
        animator = GetComponent<Animator>(); // เข้าถึง Animator ของมอนสเตอร์
        agent = GetComponent<NavMeshAgent>(); // เข้าถึง NavMeshAgent
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position); // คำนวณระยะห่างจากมอนสเตอร์ถึงผู้เล่น

        if (distanceToPlayer < followRange && distanceToPlayer > stopRange)
        {
            agent.SetDestination(player.position); // ตั้งเป้าหมายให้เดินตามผู้เล่น
            animator.SetBool("is Running", true); // เปิดใช้งานอนิเมชั่น Running
            animator.SetBool("is Idle", false); // ปิดใช้งานอนิเมชั่น Idle
        }
        else
        {
            agent.ResetPath(); // หยุดเดินเมื่ออยู่นอกระยะ
            animator.SetBool("is Running", false); // ปิดใช้งานอนิเมชั่น Running
            animator.SetBool("is Idle", true); // เปิดใช้งานอนิเมชั่น Idle
        }
    }
}
