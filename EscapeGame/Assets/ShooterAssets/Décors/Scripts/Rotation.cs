using UnityEngine;

public class Rotation : MonoBehaviour
{
    //private Transform ascenseur;
    private Vector3 deplacement;

    public float vitesseR;
    

    private void Start()
    {
        deplacement = new Vector3(0f, vitesseR, 0f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.Rotate(deplacement);
    }

}
