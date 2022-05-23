using System.Collections.Generic;
using UnityEngine;

public class Aim_epreuve1 : MonoBehaviour
{
    public List<Cible> list;
    public bool start = false;

    public BoutonStart bouton;

    private void Start()
    {
        foreach (Cible cible in this.gameObject.GetComponentsInChildren<Cible>())
        {
            cible.gameObject.SetActive(false);
            list.Add(cible);
        }
    }
    void FixedUpdate()
    {
        if(bouton.isActivate)debut(true);
    }
    void debut(bool start)
    {
        if (start)
        {
            foreach (Cible cible in list)
            {
                cible.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Cible cible in list)
            {
                cible.gameObject.SetActive(false);
            }
        }
    }
}
