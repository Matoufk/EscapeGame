using UnityEngine;

public class BoutonStart : MonoBehaviour
{
    public bool isActivate = false;
    public GameObject timer;

    public void trigger()
    {
        isActivate = !isActivate;
        if(isActivate)timer.GetComponent<Timer_script>().enabled = true;
    }

}
