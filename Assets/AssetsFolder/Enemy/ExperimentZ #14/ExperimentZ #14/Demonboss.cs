using UnityEngine;
using UnityEngine.AI;

public class Demonboss : MonoBehaviour
{
    public Transform player; // ตัวแปรตำแหน่งของผู้เล่น
    public float followRange = 15f; // ระยะที่ศัตรูจะเริ่มเดินตามผู้เล่น
    public float stopRange = 2f; // ระยะที่ศัตรูจะหยุดเมื่อเข้าใกล้ผู้เล่น

    private NavMeshAgent agent; // ตัวแปรสำหรับ NavMeshAgent
    private Animator animator; // ตัวแปรสำหรับ Animator

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // เข้าถึง NavMeshAgent ของศัตรู
        animator = GetComponent<Animator>(); // เข้าถึง Animator ของศัตรู
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position); // คำนวณระยะห่างระหว่างศัตรูกับผู้เล่น

        if (distanceToPlayer < followRange && distanceToPlayer > stopRange)
        {
            agent.SetDestination(player.position); // ให้ศัตรูเดินตามตำแหน่งผู้เล่น
            animator.SetBool("Running", true); // เปิดใช้งานอนิเมชัน Running
            animator.SetBool("Idle", false); // ปิดใช้งานอนิเมชัน Idle
        }
        else
        {
            agent.ResetPath(); // หยุดการเคลื่อนที่ของศัตรู
            animator.SetBool("Running", false); // ปิดใช้งานอนิเมชัน Running
            animator.SetBool("Idle", true); // เปิดใช้งานอนิเมชัน Idle
        }
    }
}
