using UnityEngine;

public class followDemon : MonoBehaviour
{
    public Transform player;  // ตัวอ้างอิงตำแหน่งของผู้เล่น
    public float followRange = 10f;  // ระยะที่ศัตรูเริ่มติดตามผู้เล่น
    public float stopRange = 2f;  // ระยะที่ศัตรูจะหยุดก่อนถึงผู้เล่น
    public float speed = 3f;  // ความเร็วในการเคลื่อนที่ของศัตรู

    private void Update()
    {
        // คำนวณระยะห่างระหว่างศัตรูกับผู้เล่น
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // ถ้าอยู่ในระยะที่กำหนด และไม่ได้อยู่ใกล้เกินไป
        if (distanceToPlayer <= followRange && distanceToPlayer > stopRange)
        {
            // เคลื่อนที่เข้าหาผู้เล่น
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // หมุนศัตรูให้หันหน้าหาผู้เล่น
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        }
    }

    private void OnDrawGizmosSelected()
    {
        // แสดงระยะของการติดตามและการหยุดใน Editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, followRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopRange);
    }
}
