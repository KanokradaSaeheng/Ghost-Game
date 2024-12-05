using UnityEngine;

public class fift : MonoBehaviour
{
    public Transform player; // ���������Ѻ��ҧ�֧���˹觢ͧ Player
    public float speed = 5f; // ��������㹡������͹���ͧ Enemy

    void Update()
    {
        // �ӹǳ��ȷҧ�����ҧ Enemy �Ѻ Player
        Vector3 direction = player.position - transform.position;

        // �����੾��᡹ X ��� Z (2D) ����᡹����ͧ���㹡ó� 3D
        direction.y = 0;

        // �ѹ˹�� Enemy �㹷�ȷҧ�ͧ Player
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
    }
}
