using System.Collections;
using System.Collections.Generic;
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
    public float range = 5;

    //inventaire
    private Vector3 storage;
    private GameObject[] inventaire;
    private GameObject[] IconInventaire;
    private int tailleInventaire;
    int nbObj;

    public GameObject icon0;
    public GameObject icon1;
    public GameObject icon2;
    public GameObject icon3;
    public GameObject icon4;
    public GameObject icon5;
   

    int currentObjectEquip;
    GameObject temp;


    private void Start()
    {
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
        



        nbObj = 0;
    }


    void Update()
    {
        Yrot -= Input.GetAxis("Mouse Y");
        Yrot = Mathf.Clamp(Yrot, -80, 80);
        transform.localRotation = Quaternion.Euler(Yrot, 0, 0);
       /* if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, range) && hit.transform.GetComponent<Rigidbody>())
        {
            grabOBJ = hit.transform.gameObject;
           
        }
        else if (Input.GetMouseButtonUp(0))
        {
            grabOBJ = null;
        }*/
        if (grabOBJ != null)
        {
            grabOBJ.GetComponent<Rigidbody>().velocity = 10 * (grabPos.position - grabOBJ.transform.position);
        }

        // epreuve 1 cubeColors
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, range) && hit.transform.tag == "colorcube")
        {
            hit.transform.GetComponent<coloursCode>().changeColor();
            if (epreuve1.transform.GetComponent<ColorsAchieved>().Gagne() == true) epreuve1.transform.GetComponent<ColorsAchieved>().Open();

        }

        // bouton test porte
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
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

        }
        collect();
        equip();
    }

    void collect()
    {
        if (Input.GetKeyDown("f") && Physics.Raycast(transform.position, transform.forward, out hit, range) && hit.transform.GetComponent<Rigidbody>() && hit.transform.tag =="collectible")
        {

            hit.transform.position = storage;
            nbObj++;
            inventaire[nbObj] = hit.transform.gameObject;
            IconInventaire[nbObj].SetActive(true);
            IconInventaire[nbObj].GetComponent<Image>().sprite = hit.transform.GetComponent<Image>().sprite;
            
        }
    }

    void equip()
    {
        if (Input.GetKeyDown("1"))
        {
            currentObjectEquip = 0;
        }
        if (Input.GetKeyDown("2"))
        { 
            currentObjectEquip = 1;
            if (grabOBJ != null) grabOBJ.transform.position = storage;
            grabOBJ = inventaire[1];
        }
        if (Input.GetKeyDown("3"))
        {
            currentObjectEquip = 2;
            if (grabOBJ != null) grabOBJ.transform.position = storage;
            grabOBJ = inventaire[2];
        }
        if (Input.GetKeyDown("4"))
        {
            currentObjectEquip = 3;
            if (grabOBJ != null) grabOBJ.transform.position = storage;
            grabOBJ = inventaire[3];
        }
        if (Input.GetKeyDown("5"))
        {
            currentObjectEquip = 4;
            if (grabOBJ != null) grabOBJ.transform.position = storage;
            grabOBJ = inventaire[4];
        }
        if (Input.GetKeyDown("6"))
        {
            currentObjectEquip = 5;
            if (grabOBJ != null) grabOBJ.transform.position = storage;
            grabOBJ = inventaire[5];
        }

        if (currentObjectEquip == 0)
        {
            if (grabOBJ != null)
            {
                temp = grabOBJ;
                grabOBJ = null;
                temp.transform.position = storage;
            }
        }
    }

    void drop()
    {
        if (Input.GetKeyDown("x"))
        {
            if (currentObjectEquip != 0)
            {

            }
        }
    }
}