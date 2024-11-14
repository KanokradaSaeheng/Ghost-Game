using UnityEngine;

public class Follow_camera : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;
    public float zoffset = -15f;
    // public float xoffset = 2f;

    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, zoffset);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);

    }
}
