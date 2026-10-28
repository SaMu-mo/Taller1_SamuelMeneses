using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 2f, -10f);
    public float smoothSpeed = 5f;

    private Vector3 followPosition;

    void Start()
    {
        followPosition = transform.position;
    }

    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        followPosition = Vector3.Lerp(followPosition, desiredPosition, smoothSpeed * Time.deltaTime);

        Vector3 shake = Vector3.zero;
        if (CameraShake.Instance != null)
        {
            shake = CameraShake.Instance.ShakeOffset;
        }

        transform.position = followPosition + shake;
    }
}