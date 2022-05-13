using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraScript : MonoBehaviour
{
    float Yrot;
    RaycastHit hit;
    GameObject grabOBJ;
    public Transform grabPos;
    private coloursCode colorCode;
    public GameObject epreuve1;
    public float range = 5;
    
    void Update()
    {
        Yrot -= Input.GetAxis("Mouse Y");
        Yrot = Mathf.Clamp(Yrot, -80, 80);
        transform.localRotation = Quaternion.Euler(Yrot, 0, 0);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, range) && hit.transform.GetComponent<Rigidbody>())
        {
            grabOBJ = hit.transform.gameObject;
           
        }
        else if (Input.GetMouseButtonUp(0))
        {
            grabOBJ = null;
        }
        if (grabOBJ)
        {
            grabOBJ.GetComponent<Rigidbody>().velocity = 10 * (grabPos.position - grabOBJ.transform.position);
        }

        // epreuve 1 cubeColors
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, range) && hit.transform.tag == "colorcube")
        {
            hit.transform.GetComponent<coloursCode>().changeColor();
            if (epreuve1.transform.GetComponent<ColorsAchieved>().Gagne() == true) epreuve1.transform.GetComponent<ColorsAchieved>().Open();

        }
    }
}