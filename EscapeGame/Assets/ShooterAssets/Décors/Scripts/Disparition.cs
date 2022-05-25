using UnityEngine;

public class Disparition : MonoBehaviour
{
    public float coolDown = 1.5f;
    public float curentTime;
    private bool activate = true;

    private void Start()
    {
        curentTime = 0f;
    }

    private void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad - curentTime >= coolDown && !this.gameObject.GetComponent<Cible>().isDestroy)
        {
            activate = !activate;
            disparition(activate);
            curentTime = Time.time;
            //Debug.Log("CoolDown");
        }
    }
    void disparition(bool activate)
    {

        foreach(Renderer rend in this.gameObject.GetComponentsInChildren<Renderer>())
        {
            rend.enabled = activate;
        } 
        this.gameObject.GetComponentInChildren<Collider>().enabled = activate;    
    }
}
