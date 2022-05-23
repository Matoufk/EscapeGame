using UnityEngine;

public class BoutonStart : MonoBehaviour
{
    public bool isActivate = false;

    public void trigger()
    {
        isActivate = !isActivate;
    }
}
