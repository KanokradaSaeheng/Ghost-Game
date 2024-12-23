using UnityEngine;

public class Light_Change : MonoBehaviour
{
    [Header("Light Settings")]
    [Header("Go to script for setting!")]
    public UnityEngine.Rendering.Universal.Light2D spotLight; // อ้างอิง Spot Light 2D
    private float minIntensity = 0.25f; // ค่าความเข้มต่ำสุด
    private float maxIntensity = 1.11f; // ค่าความเข้มสูงสุด
    private float duration = 2.5f; // ระยะเวลาที่ใช้ในการเปลี่ยนความเข้ม

    private bool isIncreasing = true; // กำหนดสถานะเพิ่มหรือลด

    void Update()
    {
        if (spotLight != null)
        {
            // คำนวณอัตราการเปลี่ยนแปลง
            float delta = Time.deltaTime / duration;

            // เพิ่มหรือลด Intensity
            if (isIncreasing)
            {
                spotLight.intensity += delta * (maxIntensity - minIntensity);
                if (spotLight.intensity >= maxIntensity)
                {
                    spotLight.intensity = maxIntensity;
                    isIncreasing = false; // สลับไปลดความเข้ม
                }
            }
            else
            {
                spotLight.intensity -= delta * (maxIntensity - minIntensity);
                if (spotLight.intensity <= minIntensity)
                {
                    spotLight.intensity = minIntensity;
                    isIncreasing = true; // สลับไปเพิ่มความเข้ม
                }
            }
        }
    }
}
