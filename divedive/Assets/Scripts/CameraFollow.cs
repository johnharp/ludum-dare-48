
using UnityEngine;

// https://www.youtube.com/watch?v=OUblaHNECCI
// samyam
public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform Target;

    private Vector3 Offset;
    private Vector3 Velocity = Vector3.zero;

    [SerializeField]
    private float SmoothTime = 0.2f;

    private void Start()
    {
        Offset = transform.position - Target.position;
    }

    private void LateUpdate()
    {
        Vector3 position = Target.position + Offset;
        transform.position = Vector3.SmoothDamp(
            transform.position, position, ref Velocity, SmoothTime);
    }
}
