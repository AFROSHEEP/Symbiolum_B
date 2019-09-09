using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed;
    public float rotation_speed;
    public Vector3 offset;

    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        //Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotation_speed, Vector3.up);

        //offset = camTurnAngle * offset;

        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPos;

        transform.LookAt(target.position);
    }
}
