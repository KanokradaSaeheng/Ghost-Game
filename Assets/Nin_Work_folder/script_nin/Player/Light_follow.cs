using UnityEngine;

public class FreeformLightFollowMouse : MonoBehaviour
{
    public Transform player; // อ้างอิงถึงตำแหน่งของผู้เล่น

    void Update()
    {
        if (player == null) return; // ถ้าไม่มีผู้เล่น ให้หยุดการทำงานของโค้ด

        // ตั้งตำแหน่งของแสงให้อยู่ตรงกับตำแหน่งของผู้เล่น โดยตั้งค่า Z เป็น 0
        transform.position = new Vector3(player.position.x, player.position.y, 0f);

        // รับตำแหน่งของเมาส์ในพิกัดหน้าจอ
        Vector3 mouseScreenPosition = Input.mousePosition;

        // แปลงตำแหน่งของเมาส์จากพิกัดหน้าจอเป็นพิกัดโลก
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        // คำนวณมุมหมุนของแสงเพื่อให้หันไปทางเมาส์
        Vector3 direction = mouseWorldPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ตรวจสอบว่าผู้เล่นหันไปทางขวาหรือซ้าย และปรับมุมตามทิศทางการหัน
        if (player.localScale.x < 0) // ถ้าผู้เล่นหันไปทางซ้าย
        {
            angle += 180f; // ปรับมุมเพิ่ม 180 องศาเมื่อหันไปทางซ้าย
        }

        // หมุนแสงไปตามมุมที่คำนวณได้
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
