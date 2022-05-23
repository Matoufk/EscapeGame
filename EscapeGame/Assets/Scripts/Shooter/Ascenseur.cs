using UnityEngine;

public class Ascenseur2 : MonoBehaviour
{
    //private Transform ascenseur;
    private Vector3 deplacement;

    private bool descente = true;
    private void Start()
    {
        deplacement = new Vector3(0f, 0.15f, 0f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y >= 0.1 && descente)
        {
            descente = true;
        }
        else
        {
            descente = false;
        }

        if (transform.position.y <= 26.5 && !descente)
        {
            descente = false;
        }
        else
        {
            descente = true;
        }



        if (descente)
        {

            _descente();
        }
        else
        {
            _monte();
        }

    }

    void _monte()
    {
        transform.position += deplacement;
    }
    void _descente()
    {
        transform.position -= deplacement;
    }
}
