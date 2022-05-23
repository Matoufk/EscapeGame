using UnityEngine;

public class Ascenseur : MonoBehaviour
{
    //private Transform ascenseur;
    private Vector3 deplacement;

    private bool descente = true;
    private void Start()
    {
        deplacement = new Vector3(0f, 0.1f, 0f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y >= 0.1 && descente)
        {
            descente = true;
        }
        else { descente = false; }

        if (transform.position.y <= 18 && !descente)
        {
            descente = false;
        }
        else
        {
            descente = true;
        }



        if (descente)
        {

            transform.position -= deplacement;
        }
        else
        {
            transform.position += deplacement;
        }
    }
}
