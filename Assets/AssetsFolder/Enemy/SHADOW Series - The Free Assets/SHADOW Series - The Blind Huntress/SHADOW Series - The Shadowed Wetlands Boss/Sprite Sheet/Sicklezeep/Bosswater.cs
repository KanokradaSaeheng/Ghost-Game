using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public Transform player;          // ����õ��˹觢ͧ������
    public float followRange = 5f;    // ���з���͹������������Թ���������
    public float attackRange = 1f;    // ���з���͹��������������ռ�����
    public float speed = 2f;          // �������Ǣͧ�͹�����
    private bool isFollowing = false; // ʶҹ�����͹�������ѧ�Թ��������������������
    private bool isAttacking = false; // ʶҹ�����͹�������ѧ���������������

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            // ��Ҽ������������������ ������������
            AttackPlayer();
        }
        else if (distanceToPlayer <= followRange)
        {
            // ��Ҽ���������������Թ��� �������������������� ����Թ���������
            FollowPlayer();
        }
        else
        {
            // �������͡�����Թ��� ��ش�Թ���
            StopFollowing();
        }
    }

    void FollowPlayer()
    {
        if (!isFollowing)
        {
            isFollowing = true;
            Debug.Log("�͹�����������Թ���������");
        }

        // �ӹǳ��ȷҧ����Ҽ�����
        Vector2 direction = (player.position - transform.position).normalized;

        // ����͹�����ѧ���˹觢ͧ������
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        // ��ش������ն�ҡ��ѧ�Թ���
        isAttacking = false;
    }

    void StopFollowing()
    {
        if (isFollowing)
        {
            isFollowing = false;
            Debug.Log("�͹�������ش�Թ���������");
        }
    }

    void AttackPlayer()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            Debug.Log("�͹�������ѧ���ռ�����!");

            // �����ռ������������������ �� Ŵ HP �ͧ������
        }
    }
}
