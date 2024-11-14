using UnityEngine;

public class playerfollow : MonoBehaviour
{
    public Transform player;         // ����õ��˹觢ͧ������
    public float followRange = 5f;   // ���з���͹������������Թ���
    public float speed = 2f;         // ��������㹡������͹���ͧ�͹�����

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // ��Ҽ�������������� followRange ����Թ���
        if (distanceToPlayer <= followRange)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        // �ӹǳ��ȷҧ��ѧ������
        Vector2 direction = (player.position - transform.position).normalized;

        // ����͹�����ѧ���˹觢ͧ�����蹴��¤������Ƿ���˹�
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
