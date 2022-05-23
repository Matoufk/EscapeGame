using UnityEngine;

public class MonteDescendre : MonoBehaviour
{
    //private Transform ascenseur;
    private Vector3 deplacement;

    private bool descente = true;

    public float vitesseY;
    public float hauteurMini = 1.25f;
    public float hauteurMax;

    private void Start()
    {
        deplacement = new Vector3(0f, vitesseY, 0f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y >= hauteurMini && descente)
        {
            descente = true;
        }
        else
        {
            descente = false;
        }

        if (transform.position.y <= hauteurMax && !descente)
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
