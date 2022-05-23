using UnityEngine;

public class GaucheDroite : MonoBehaviour
{
    //private Transform ascenseur;
    private Vector3 deplacement;

    private bool gauche;

    public float vitesseX;
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
        deplacement = new Vector3(vitesseX, 0f, 0f);
        gaucheMax = transform.position.x - gaucheMax;
        droiteMax = transform.position.x + droiteMax;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x >= gaucheMax && gauche)
        {
            gauche = true;
        }
        else
        {
            gauche = false;
        }

        if (transform.position.x <= droiteMax && !gauche)
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
