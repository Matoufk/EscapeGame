using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placing : MonoBehaviour
{
    private Transform item;
    int currentObjectEquip;

    // Start is called before the first frame update
    void Start()
    {
        currentObjectEquip = 0;
    }

    // Update is called once per frame
    void Update()
    {
        equip();
        stateBox();
        place();
    }

    //place the item in bookshelf
    void place()
    {
        if(Input.GetKeyDown("x"))
        {
            currentObjectEquip = 0;

            if(item != null)
            {
                item.GetComponent<Rigidbody>().velocity = Vector3.zero;
                item.localPosition = this.transform.localPosition;
                item.localEulerAngles = new Vector3(0f, 0f, 0f);                
            }
        }
    }

    //Know the current object equiped
    void equip()
    {
        if(Input.GetKeyDown("1") || Input.GetKeyDown("f"))
        {
            currentObjectEquip = 0;
            item = null;
        }

        if(Input.GetKeyDown("2") || Input.GetKeyDown("3") || Input.GetKeyDown("4") ||
           Input.GetKeyDown("5") || Input.GetKeyDown("6"))
        {
            currentObjectEquip = 1;
        }
      
    }


    void OnTriggerStay(Collider other)
    {
        this.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        if(other.CompareTag("collectible"))
        {
            item = other.GetComponent<Transform>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        item = null;
    }

    //Rendering the box
    void stateBox()
    {
        if(currentObjectEquip == 0 || item != null)
        {
            this.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        }
        else
        {
            this.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
        }
    }
}
