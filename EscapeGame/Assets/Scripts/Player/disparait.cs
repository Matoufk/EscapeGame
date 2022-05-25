using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparait : MonoBehaviour
{
    public GameObject collectible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Renderer>() != null) this.GetComponent<Renderer>().enabled = collectible.GetComponent<Renderer>().enabled;
        if (this.GetComponent<Collider>() != null) this.GetComponent<Collider>().enabled = collectible.GetComponent<Collider>().enabled;
    }
}
