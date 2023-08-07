using UnityEngine;
public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset = new Vector3(0, 2, -10f);
    [SerializeField] private float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;
    private void LateUpdate()
    {
        if (player == null)
            return;
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

}