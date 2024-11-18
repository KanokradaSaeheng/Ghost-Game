using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;             // ���˹觢ͧ������
    public float moveSpeed = 3f;         // �������ǡ������͹��Ǣͧ�ѵ��
    public float attackRange = 1.5f;     // ���з������ö���ռ�������
    public float stoppingDistance = 0.5f; // ���з���ѵ����ش�Թ�������������
    public float attackCooldown = 1f;   // ���Ҥ�Ŵ�ǹ������ҧ����������Ф���

    private Animator animator;           // ����� Animator
    private float attackTimer = 0f;      // ��ǨѺ��������
    private bool isAttacking = false;    // ����ҡ��ѧ�����������

    void Start()
    {
        animator = GetComponent<Animator>(); // ��Ҷ֧ Animator �ͧ GameObject
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > attackRange) // �ѵ���������Թ��������
        {
            MoveTowardsPlayer();
        }
        else // �ѵ���������������
        {
            if (!isAttacking && attackTimer <= 0f)
            {
                StartAttack();
            }
        }

        // Ŵ���� Cooldown �ͧ�������
        if (attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
        }
    }

    void MoveTowardsPlayer()
    {
        if (isAttacking) return; // ��ҡ��ѧ���ը��������͹���

        Vector2 direction = (player.position - transform.position).normalized; // �ӹǳ��ȷҧ
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime; // ����͹���

        // �Դ͹����ѹ�Թ
        animator.SetBool("isWalking", true);
        animator.SetBool("isAttacking", false);
    }

    void StartAttack()
    {
        isAttacking = true; // ���������
        attackTimer = attackCooldown; // ��駤�����Ҥ�Ŵ�ǹ�

        // �Դ͹����ѹ����
        animator.SetBool("isWalking", false);
        animator.SetBool("isAttacking", true);

        Debug.Log("Enemy attacks!");
        // ���¡��ѧ��ѹ�Ӥ����������
        Invoke(nameof(DealDamage), 0.5f); // ��������˹�ǧ���ç�Ѻ͹����ѹ
    }

    void StopAttack()
    {
        isAttacking = false; // ��ش����
        animator.SetBool("isAttacking", false); // �Դ͹����ѹ����
    }

    void DealDamage()
    {
        // ������÷Ӥ���������� (����Ҽ������ѧ���������)
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // ���ҧ����������� 10 ˹���
                Debug.Log("Player took damage!");
            }
        }

        StopAttack(); // ��ش������ѧ���ҧ�����������
    }
}
