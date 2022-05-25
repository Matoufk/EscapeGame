using UnityEngine;

public class DisparitionCible : MonoBehaviour
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
        if(Time.timeSinceLevelLoad - curentTime >= coolDown)
        {
            activate = !activate;
            disparition(activate);
            curentTime = Time.timeSinceLevelLoad;
            Debug.Log("CoolDown");
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
