using UnityEngine;
using UnityEngine.UI;


public class CameraScript : MonoBehaviour
{
    float Yrot;
    RaycastHit hit;
    GameObject grabOBJ;
    public Transform grabPos;
    private coloursCode colorCode;
    public GameObject epreuve1;
    public float range = 10f;
    Vector3 vecCam;

    //inventaire
    private Vector3 storage;
    private GameObject[] inventaire;
    private GameObject[] IconInventaire;
    private int tailleInventaire;
    int nbObj;
    int currentObjectEquip;

    //icons
    public GameObject icon0;
    public GameObject icon1;
    public GameObject icon2;
    public GameObject icon3;
    public GameObject icon4;
    public GameObject icon5;

    public GameObject text_F;


    //Test GUN
    public bool asGun = false;
    float Xrot;
    public WeaponGraphics graphics;

    private void Start()
    {
        asGun = false;
        grabOBJ = null;
        tailleInventaire = 6;
        storage = new Vector3(0, -10, 0);
        inventaire = new GameObject[tailleInventaire];
        IconInventaire = new GameObject[tailleInventaire];
        IconInventaire[0] = icon0;
        IconInventaire[1] = icon1;
        IconInventaire[2] = icon2;
        IconInventaire[3] = icon3;
        IconInventaire[4] = icon4;
        IconInventaire[5] = icon5;

       vecCam = Vector3.zero;
        range = 10f;



        nbObj = 0;
    }


    void Update()
    {
        Yrot -= Input.GetAxis("Mouse Y");
        Yrot = Mathf.Clamp(Yrot, -80, 80);
        transform.localRotation = Quaternion.Euler(Yrot, 0, 0);

        Xrot -= Input.GetAxis("Mouse X");
        /* if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, range) && hit.transform.GetComponent<Rigidbody>())
         {
             grabOBJ = hit.transform.gameObject;

         }
         else if (Input.GetMouseButtonUp(0))
         {
             grabOBJ = null;
         }
         if (grabOBJ != null)
         {
             grabOBJ.GetComponent<Rigidbody>().velocity = 10 * (grabPos.position - grabOBJ.transform.position);
         }*/
        for (int i = 0; i < inventaire.Length; i++)
        {
            if (inventaire[i]!=null && !(inventaire[i].GetComponent<IsGun>() != null && inventaire[i].GetComponent<IsGun>().isGun)) inventaire[i].GetComponent<Rigidbody>().velocity = 10 * (grabPos.position - inventaire[i].transform.position);
            if (inventaire[i] != null && (inventaire[i].GetComponent<IsGun>() != null && inventaire[i].GetComponent<IsGun>().isGun))
            {
               // Vector3 offSetPos = new Vector3(0.5f, -0.5f, 0f);
                //Vector3 offSetPos2 = new Vector3(-1f, 0f, -1f);
                float offRot =-90f;
                inventaire[i].GetComponent<Rigidbody>().detectCollisions = false;
                // inventaire[i].GetComponent<Rigidbody>().position = this.transform.position+offSetPos;
                inventaire[i].GetComponent<Transform>().position = this.transform.GetChild(0).position;// + offSetPos2;
               inventaire[i].GetComponent<Transform>().localRotation = Quaternion.Euler(Yrot+offRot, -Xrot, 0);
                graphics = inventaire[i].GetComponent<WeaponGraphics>();
            }
        }

        porte();
        epreuveColors();
        collect();
        equip();
        drop();
        if(grabOBJ != null && grabOBJ.GetComponent<IsGun>() == null)rotate();
    }
    void porte()
    {
        // bouton test porte
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, range))
        {   
            //Si on a une porte
            if (hit.transform.GetComponent<OpenDoor>() != null)
            {
                if (hit.transform.GetComponent<OpenDoor>().isOpen)
                {
                    hit.transform.GetComponent<OpenDoor>().closeDoor();
                }
                else
                {
                    hit.transform.GetComponent<OpenDoor>().openDoor();
                }
            }
            //Si on a un bouton de début d'épreuve
            if (hit.transform.GetComponent<BoutonStart>() != null)
            {
                hit.transform.GetComponent<BoutonStart>().trigger();
            }
        }
    }
    void epreuveColors()
    {
        // epreuve 1 cubeColors
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, range) && hit.transform.tag == "colorcube")
        {
            hit.transform.GetComponent<coloursCode>().changeColor();
            if (epreuve1.transform.GetComponent<ColorsAchieved>().Gagne() == true) epreuve1.transform.GetComponent<ColorsAchieved>().Open();

        }

    }
    
    void collect()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range) && hit.transform.GetComponent<Rigidbody>() && hit.transform.tag == "collectible" && currentObjectEquip == 0){
            text_F.SetActive(true);
        }
        else text_F.SetActive(false);


        if (Input.GetKeyDown("f") && Physics.Raycast(transform.position, transform.forward, out hit, range) && hit.transform.GetComponent<Rigidbody>() && hit.transform.tag == "collectible" && currentObjectEquip == 0)
        {

            //hit.transform.position = storage;
            //hit.transform.gameObject.SetActive(false);
            hit.transform.gameObject.GetComponent<Renderer>().enabled = false;
            hit.transform.gameObject.GetComponent<Collider>().enabled = false;

            //Gestion du gun
            /*if (hit.transform.gameObject.GetComponent<IsGun>() != null && hit.transform.gameObject.GetComponent<IsGun>().isGun)
            {
                asGun = true;
            }
            */

            int i = 1;
            if (nbObj < 5)
            {
                while (inventaire[i] != null)
                {
                    if (i < 5) i++;
                    else i = 1;
                }
                inventaire[i] = hit.transform.gameObject;
                IconInventaire[i].SetActive(true);
                IconInventaire[i].GetComponent<Image>().sprite = hit.transform.GetComponent<Image>().sprite;
                nbObj++;
            }
        }
    }

    void equip()
    {
        if (Input.GetKeyDown("1"))
        {
            currentObjectEquip = 0;
            asGun = false;
        }
        if (Input.GetKeyDown("2") && inventaire[1] != null)
        { 
            currentObjectEquip = 1;
            if (grabOBJ != null)
            {
                grabOBJ.transform.gameObject.GetComponent<Renderer>().enabled = false;//grabOBJ.transform.position = storage;
                grabOBJ.transform.gameObject.GetComponent<Collider>().enabled = false;
            }
                grabOBJ = inventaire[1];
            grabOBJ.transform.gameObject.GetComponent<Renderer>().enabled = true;//grabOBJ.transform.position = storage;
            grabOBJ.transform.gameObject.GetComponent<Collider>().enabled = true;
            if (grabOBJ.GetComponent<IsGun>() != null)
            {
                asGun = true;
            } else
            {
                asGun = false;
            }
        }
        if (Input.GetKeyDown("3") && inventaire[2] != null)
        {
            currentObjectEquip = 2;
            if (grabOBJ != null)
            {
                grabOBJ.transform.gameObject.GetComponent<Renderer>().enabled = false;//grabOBJ.transform.position = storage;
                grabOBJ.transform.gameObject.GetComponent<Collider>().enabled = false;
            }
            grabOBJ = inventaire[2];
            grabOBJ.transform.gameObject.GetComponent<Renderer>().enabled = true;//grabOBJ.transform.position = storage;
            grabOBJ.transform.gameObject.GetComponent<Collider>().enabled = true;
            if (grabOBJ.GetComponent<IsGun>() != null)
            {
                asGun = true;
            }
            else
            {
                asGun = false;
            }
        }
        if (Input.GetKeyDown("4") && inventaire[3] != null)
        {
            currentObjectEquip = 3;
            if (grabOBJ != null)
            {
                grabOBJ.transform.gameObject.GetComponent<Renderer>().enabled = false;//grabOBJ.transform.position = storage;
                grabOBJ.transform.gameObject.GetComponent<Collider>().enabled = false;
            }
            grabOBJ = inventaire[3];
            grabOBJ.transform.gameObject.GetComponent<Renderer>().enabled = true;//grabOBJ.transform.position = storage;
            grabOBJ.transform.gameObject.GetComponent<Collider>().enabled = true;
            if (grabOBJ.GetComponent<IsGun>() != null)
            {
                asGun = true;
            }
            else
            {
                asGun = false;
            }
        }
        if (Input.GetKeyDown("5") && inventaire[4] != null)
        {
            currentObjectEquip = 4;
            if (grabOBJ != null)
            {
                grabOBJ.transform.gameObject.GetComponent<Renderer>().enabled = false;//grabOBJ.transform.position = storage;
                grabOBJ.transform.gameObject.GetComponent<Collider>().enabled = false;
            }
            grabOBJ = inventaire[4];
            grabOBJ.transform.gameObject.GetComponent<Renderer>().enabled = true;//grabOBJ.transform.position = storage;
            grabOBJ.transform.gameObject.GetComponent<Collider>().enabled = true;
            if (grabOBJ.GetComponent<IsGun>() != null)
            {
                asGun = true;
            }
            else
            {
                asGun = false;
            }
        }
        if (Input.GetKeyDown("6") && inventaire[5] != null)
        {
            currentObjectEquip = 5;
            if (grabOBJ != null)
            {
                grabOBJ.transform.gameObject.GetComponent<Renderer>().enabled = false;//grabOBJ.transform.position = storage;
                grabOBJ.transform.gameObject.GetComponent<Collider>().enabled = false;
            }
            grabOBJ = inventaire[5];
            grabOBJ.transform.gameObject.GetComponent<Renderer>().enabled = true;//grabOBJ.transform.position = storage;
            grabOBJ.transform.gameObject.GetComponent<Collider>().enabled = true;
            if (grabOBJ.GetComponent<IsGun>() != null)
            {
                asGun = true;
            }
            else
            {
                asGun = false;
            }
        }

        if (currentObjectEquip == 0)
        {
            if (grabOBJ != null)
            {
                grabOBJ.transform.gameObject.GetComponent<Renderer>().enabled = false;//grabOBJ.transform.position = storage;
                grabOBJ.transform.gameObject.GetComponent<Collider>().enabled = false;
                grabOBJ = null;
            }
            asGun = false;
        }
    }

    void drop()
    {
        if (Input.GetKeyDown("x"))
        {
            if (currentObjectEquip != 0)
            {
                //Si c'est un gun on réactive sont rigid body car je l'avais désac au dessus pour pouvoir le reprendre
                if (grabOBJ.GetComponent<IsGun>() != null)
                {
                    asGun = false;
                    grabOBJ.transform.GetComponent<Rigidbody>().detectCollisions = true;
                }

                grabOBJ.transform.GetComponent<Rigidbody>().freezeRotation = false;
                grabOBJ = null;
                nbObj--;
                inventaire[currentObjectEquip] = null;
                IconInventaire[currentObjectEquip].SetActive(false);
                currentObjectEquip = 0;
            }
        }
    }

    void rotate()
    {
        if (grabOBJ != null)
        {
            if (Input.anyKeyDown)
            {
                grabOBJ.transform.GetComponent<Rigidbody>().freezeRotation = true;
                grabOBJ.transform.GetComponent<Rigidbody>().freezeRotation = false;
            }
            if (Input.GetButton("RotateUp"))
            {
                grabOBJ.transform.Rotate(Vector3.up * 120 * Time.deltaTime);
            }
            else if (Input.GetButton("RotateDown"))
            {
                grabOBJ.transform.Rotate(Vector3.up * -120f * Time.deltaTime);
            }
            else if (Input.GetButton("RotateLeft"))
            {
                grabOBJ.transform.Rotate(Vector3.right * 120f * Time.deltaTime);
            }
            else if (Input.GetButton("RotateRight"))
            {
                grabOBJ.transform.Rotate(Vector3.right * -120f * Time.deltaTime);
            }
            else
            {
                grabOBJ.transform.eulerAngles -= (vecCam-this.transform.eulerAngles);
                vecCam = this.transform.eulerAngles;
            }
        }

    }
}