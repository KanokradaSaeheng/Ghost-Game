using UnityEngine;

public class Demon : MonoBehaviour
{
    public Transform player;             // ��ҧ�ԧ���˹觢ͧ������
    public float moveSpeed = 3f;         // ��������㹡������͹���ͧ�͹�����
    public float stoppingDistance = 1f;  // ������ҧ����͹��������ش���������

    private Animator animator;           // ���������Ѻ Animator

    private void Start()
    {
        animator = GetComponent<Animator>(); // ��Ҷ֧ Animator �ͧ�͹�����
    }

    private void Update()
    {
        if (player == null) return; // ���������˹������� ��� return

        float distance = Vector3.Distance(transform.position, player.position);

        // ��Ǩ�ͺ����͹������èе���������������
        if (distance > stoppingDistance)
        {
            // �ӹǳ��ȷҧ��Ҽ�����
            Vector3 direction = (player.position - transform.position).normalized;

            // ����͹����͹�����㹷�ȷҧ���
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // �Դ��ҹ͹������ Running
            animator.SetBool("Running", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            // ��ش�������͹����������¹��͹������ Idle
            animator.SetBool("Running", false);
            animator.SetBool("Idle", true);
        }
    }
}
