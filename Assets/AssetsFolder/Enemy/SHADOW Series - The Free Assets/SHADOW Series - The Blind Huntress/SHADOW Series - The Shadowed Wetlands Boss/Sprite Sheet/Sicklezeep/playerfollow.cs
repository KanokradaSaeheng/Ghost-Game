using UnityEngine;

public class playerfollow : MonoBehaviour
{
    public Transform player;         // ตัวแปรตำแหน่งของผู้เล่น
    public float followRange = 5f;   // ระยะที่มอนสเตอร์จะเริ่มเดินตาม
    public float speed = 2f;         // ความเร็วในการเคลื่อนที่ของมอนสเตอร์

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // ถ้าผู้เล่นอยู่ในระยะ followRange ให้เดินตาม
        if (distanceToPlayer <= followRange)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        // คำนวณทิศทางไปยังผู้เล่น
        Vector2 direction = (player.position - transform.position).normalized;

        // เคลื่อนที่ไปยังตำแหน่งของผู้เล่นด้วยความเร็วที่กำหนด
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
