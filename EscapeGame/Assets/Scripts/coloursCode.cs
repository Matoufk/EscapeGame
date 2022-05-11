using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coloursCode : MonoBehaviour
{

    public Material red;
    public Material green;
    public Material purple;
    public Material blue;
    public Material yellow;
    public string color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeColor()
    {
        if (color == "red")
        {
            this.GetComponent<Renderer>().material = green;
            color = "green";
        }
        else if (color == "green")
        {
            color = "purple";
            this.GetComponent<Renderer>().material = purple;
        }
        else if (color == "purple")
        {
            this.GetComponent<Renderer>().material = blue;
            color = "blue";
        }
        else if (color == "blue")
        {
            this.GetComponent<Renderer>().material = yellow;
            color = "yellow";
        }
        else if (color == "yellow")
        {
            this.GetComponent<Renderer>().material = red;
            color = "red";
        }
        }
}
