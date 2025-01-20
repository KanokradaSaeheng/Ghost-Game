using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    // ใส่ชื่อฉากที่จะเปลี่ยนไป
    [SerializeField] private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ตรวจสอบว่าผู้เล่นชนกับวัตถุ
        if (collision.CompareTag("Player"))
        {
            // โหลดฉากใหม่ที่กำหนดไว้
            SceneManager.LoadScene(9);
        }
    }
}
