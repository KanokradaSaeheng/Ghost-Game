using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    // �����ͩҡ��������¹�
    [SerializeField] private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��Ǩ�ͺ��Ҽ����蹪��Ѻ�ѵ��
        if (collision.CompareTag("Player"))
        {
            // ��Ŵ�ҡ�������˹����
            SceneManager.LoadScene(9);
        }
    }
}
