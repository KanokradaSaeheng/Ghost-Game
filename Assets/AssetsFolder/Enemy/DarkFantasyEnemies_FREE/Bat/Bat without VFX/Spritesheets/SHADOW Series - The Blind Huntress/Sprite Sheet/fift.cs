using UnityEngine;

public class fift : MonoBehaviour
{
    public Transform player; // ตัวแปรสำหรับอ้างถึงตำแหน่งของ Player
    public float speed = 5f; // ความเร็วในการเคลื่อนที่ของ Enemy

    void Update()
    {
        // คำนวณทิศทางระหว่าง Enemy กับ Player
        Vector3 direction = player.position - transform.position;

        // ทำให้เฉพาะแกน X และ Z (2D) หรือแกนที่ต้องการในกรณี 3D
        direction.y = 0;

        // หันหน้า Enemy ไปในทิศทางของ Player
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
    }
}
