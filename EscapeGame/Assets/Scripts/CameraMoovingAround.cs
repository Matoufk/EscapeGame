using UnityEngine;

public class CameraMoovingAround : MonoBehaviour
{
    private float mouseSensitivity = 3.0f;

    private float rotationY;
    private float rotationX;

    public CameraFollow cameraFollow;

    private float distanceFromTarget = 0f;

    private Vector3 currentRoation;
    private Vector3 cameraVelocity = Vector3.zero;
    private float smoothTime = 0f;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, -40, 40);

        Vector3 nextRotation = new Vector3(rotationX, rotationY);

        currentRoation = Vector3.SmoothDamp(currentRoation, nextRotation, ref cameraVelocity, smoothTime);

        transform.localEulerAngles = currentRoation;

        transform.position = cameraFollow.target.position - transform.forward * distanceFromTarget;

        /*
        //Test Scrol Up and down
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            distanceFromTarget = Mathf.Clamp(distanceFromTarget -= 1f, 1f, 10f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            distanceFromTarget = Mathf.Clamp(distanceFromTarget += 1f, 1f, 10f);
        }
        */
    }
}
