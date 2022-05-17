using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float smoothSpeed= 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newVelocity = transform.forward * Input.GetAxis("Vertical") * speed + transform.right * Input.GetAxis("Horizontal") * speed;
       
        rb.velocity = Vector3.Lerp(rb.velocity, newVelocity, smoothSpeed);
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
    }
}
