using UnityEngine;

public class Move_back : MonoBehaviour
{
    public float speed = 2f; // ความเร็วในการขยับ
    public float range = 5f; // ระยะที่ Background จะขยับไปซ้าย-ขวา

    private Vector3 startPosition; // ตำแหน่งเริ่มต้น
    private bool movingRight = true; // ทิศทางการเคลื่อนไหว

    void Start()
    {
        startPosition = transform.position; // บันทึกตำแหน่งเริ่มต้น
    }

    void Update()
    {
        // คำนวณการขยับ
        float offset = speed * Time.deltaTime;

        if (movingRight)
        {
            transform.position += new Vector3(offset, 0, 0);

            // ตรวจสอบว่าถึงขอบขวาหรือยัง
            if (transform.position.x >= startPosition.x + range)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position -= new Vector3(offset, 0, 0);

            // ตรวจสอบว่าถึงขอบซ้ายหรือยัง
            if (transform.position.x <= startPosition.x - range)
            {
                movingRight = true;
            }
        }
    }
}
