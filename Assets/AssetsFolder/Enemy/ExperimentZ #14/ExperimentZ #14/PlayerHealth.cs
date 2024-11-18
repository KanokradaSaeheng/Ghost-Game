using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;   // พลังชีวิตสูงสุด
    private int currentHealth;   // พลังชีวิตปัจจุบัน

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage: " + damage + ", Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died!");
        // เพิ่มระบบสำหรับการตาย เช่น โหลดฉากใหม่ หรือแสดงหน้าจอเกมโอเวอร์
    }
}
