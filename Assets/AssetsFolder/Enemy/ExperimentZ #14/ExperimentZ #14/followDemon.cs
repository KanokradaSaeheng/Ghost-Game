using UnityEngine;

public class followDemon : MonoBehaviour
{
    public Transform player;  // �����ҧ�ԧ���˹觢ͧ������
    public float followRange = 10f;  // ���з���ѵ��������Դ���������
    public float stopRange = 2f;  // ���з���ѵ�٨���ش��͹�֧������
    public float speed = 3f;  // ��������㹡������͹���ͧ�ѵ��

    private void Update()
    {
        // �ӹǳ������ҧ�����ҧ�ѵ�١Ѻ������
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // �����������з���˹� ����������������Թ�
        if (distanceToPlayer <= followRange && distanceToPlayer > stopRange)
        {
            // ����͹�������Ҽ�����
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // ��ع�ѵ������ѹ˹���Ҽ�����
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        }
    }

    private void OnDrawGizmosSelected()
    {
        // �ʴ����Тͧ��õԴ�����С����ش� Editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, followRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopRange);
    }
}
