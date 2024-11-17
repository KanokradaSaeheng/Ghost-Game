using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;   // ��ѧ���Ե�٧�ش
    private int currentHealth;   // ��ѧ���Ե�Ѩ�غѹ

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
        // �����к�����Ѻ��õ�� �� ��Ŵ�ҡ���� �����ʴ�˹�Ҩ����������
    }
}
