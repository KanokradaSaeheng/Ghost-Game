using UnityEngine;

public class Platfrom_move : MonoBehaviour
{
    public Transform Position_1, Position_2;
    public int Speed;
    public float StopTime = 1.0f; // เวลาหยุดในแต่ละจุด
    Vector2 targetPas;
    private bool isWaiting = false;

    void Start()
    {
        targetPas = Position_2.position;
    }

    void Update()
    {
        if (isWaiting) return; // หยุดการเคลื่อนที่ถ้ากำลังรอ

        if (Vector2.Distance(transform.position, Position_1.position) < .1f)
        {
            StartCoroutine(WaitBeforeMoving(Position_2.position));
        }
        else if (Vector2.Distance(transform.position, Position_2.position) < .1f)
        {
            StartCoroutine(WaitBeforeMoving(Position_1.position));
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPas, Speed * Time.deltaTime);
    }

    private System.Collections.IEnumerator WaitBeforeMoving(Vector2 nextTarget)
    {
        isWaiting = true; // หยุดการเคลื่อนที่
        yield return new WaitForSeconds(StopTime); // รอเวลาที่กำหนด
        targetPas = nextTarget; // กำหนดเป้าหมายใหม่
        isWaiting = false; // เริ่มเคลื่อนที่อีกครั้ง
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.transform.SetParent(this.transform); // ผูกผู้เล่นเข้ากับแพลตฟอร์ม
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.transform.SetParent(null); // ปลดผู้เล่นจากแพลตฟอร์ม
    }
}
