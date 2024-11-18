using UnityEngine;
using UnityEngine.AI;

public class Bosssnake : MonoBehaviour
{
    public Transform player; // ���������Ѻ���˹觼�����
    public float followRange = 10f; // ���зҧ����͹������������Թ���
    public float stopRange = 2f; // ���зҧ����͹��������ش����������������
    private Animator animator; // ���������Ѻ Animator
    private NavMeshAgent agent; // ���������Ѻ NavMeshAgent

    void Start()
    {
        animator = GetComponent<Animator>(); // ��Ҷ֧ Animator �ͧ�͹�����
        agent = GetComponent<NavMeshAgent>(); // ��Ҷ֧ NavMeshAgent
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position); // �ӹǳ������ҧ�ҡ�͹�����֧������

        if (distanceToPlayer < followRange && distanceToPlayer > stopRange)
        {
            agent.SetDestination(player.position); // ��������������Թ���������
            animator.SetBool("is Running", true); // �Դ��ҹ͹������ Running
            animator.SetBool("is Idle", false); // �Դ��ҹ͹������ Idle
        }
        else
        {
            agent.ResetPath(); // ��ش�Թ���������͡����
            animator.SetBool("is Running", false); // �Դ��ҹ͹������ Running
            animator.SetBool("is Idle", true); // �Դ��ҹ͹������ Idle
        }
    }
}
