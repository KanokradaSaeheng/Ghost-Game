using UnityEngine;
using UnityEngine.AI;

public class Demonboss : MonoBehaviour
{
    public Transform player; // ����õ��˹觢ͧ������
    public float followRange = 15f; // ���з���ѵ�٨�������Թ���������
    public float stopRange = 2f; // ���з���ѵ�٨���ش����������������

    private NavMeshAgent agent; // ���������Ѻ NavMeshAgent
    private Animator animator; // ���������Ѻ Animator

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // ��Ҷ֧ NavMeshAgent �ͧ�ѵ��
        animator = GetComponent<Animator>(); // ��Ҷ֧ Animator �ͧ�ѵ��
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position); // �ӹǳ������ҧ�����ҧ�ѵ�١Ѻ������

        if (distanceToPlayer < followRange && distanceToPlayer > stopRange)
        {
            agent.SetDestination(player.position); // ����ѵ���Թ������˹觼�����
            animator.SetBool("Running", true); // �Դ��ҹ͹����ѹ Running
            animator.SetBool("Idle", false); // �Դ��ҹ͹����ѹ Idle
        }
        else
        {
            agent.ResetPath(); // ��ش�������͹���ͧ�ѵ��
            animator.SetBool("Running", false); // �Դ��ҹ͹����ѹ Running
            animator.SetBool("Idle", true); // �Դ��ҹ͹����ѹ Idle
        }
    }
}
