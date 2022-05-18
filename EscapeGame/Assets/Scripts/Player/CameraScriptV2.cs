using UnityEngine;
using UnityEngine.UI;


public class CameraScriptV2 : MonoBehaviour
{
    float Yrot;
     private void Start()
    {
       
    }


    void Update()
    {
        Yrot -= Input.GetAxis("Mouse Y");
        Yrot = Mathf.Clamp(Yrot, -80, 80);
        transform.localRotation = Quaternion.Euler(Yrot, 0, 0);
       
    }
   
}