using UnityEngine;

public class Shooting_player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 40f;
    public float bullet_destroy = 0.5f;
    private float cooldownTime = 2.5f; // ระยะเวลาคูลดาวน์ระหว่างการยิง

    private float nextFireTime = 0f; // เวลาในการยิงครั้งถัดไป

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + cooldownTime; // กำหนดเวลาสำหรับการยิงครั้งถัดไป
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector2 direction = (mousePosition - firePoint.position).normalized;

        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // ทำลายกระสุนหลังจากระยะเวลาที่กำหนด
        Destroy(bullet, bullet_destroy);
    }
}
