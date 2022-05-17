using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float smoothSpeed= 10;
    public float mouseSensitivity = 10f;
    Vector3 newVelocity;
    Vector3 rotateCamera;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        newVelocity = (transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal")).normalized * speed;

        //rb.velocity = Vector3.Lerp(rb.velocity, newVelocity, smoothSpeed);
        rotateCamera = new Vector3(0, Input.GetAxisRaw("Mouse X"), 0);// * mouseSensitivity;
        transform.Rotate(rotateCamera);
    }

    private void FixedUpdate()
    {
        if(newVelocity != Vector3.zero)rb.MovePosition(rb.position + newVelocity * Time.fixedDeltaTime);
        //rb.MoveRotation(rb.rotation * Quaternion.Euler(rotateCamera));
        

    }
}
