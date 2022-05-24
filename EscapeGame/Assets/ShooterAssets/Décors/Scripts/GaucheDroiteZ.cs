using UnityEngine;

public class GaucheDroiteZ : MonoBehaviour
{
    //private Transform ascenseur;
    private Vector3 deplacement;

    private bool gauche;

    public float vitesseZ;
    public float gaucheMax = 1.25f;
    public float droiteMax = 1.25f;

    public bool inverse = false;

    private void Start()
    {
        if (inverse)
        {
            gauche = false;
        }
        else
        {
            gauche = true;
        }
        deplacement = new Vector3(0f, 0f, vitesseZ);
        gaucheMax = transform.position.z - gaucheMax;
        droiteMax = transform.position.z + droiteMax;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.z >= gaucheMax && gauche)
        {
            gauche = true;
        }
        else
        {
            gauche = false;
        }

        if (transform.position.z <= droiteMax && !gauche)
        {
            gauche = false;
        }
        else
        {
            gauche = true;
        }

        if (gauche)
        {

            _gauche();
        }
        else
        {
            _droite();
        }

    }

    void _droite()
    {


        transform.position += deplacement;

    }
    void _gauche()
    {

        transform.position -= deplacement;

    }
}
