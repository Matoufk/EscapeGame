using System.Collections.Generic;
using UnityEngine;

public class Aim_epreuve1 : MonoBehaviour
{
    public List<Cible> list;
    public bool start = false;

    public BoutonStart bouton;
    public bool end = false;
    public Timer_script timer;

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
        for (int i = 0; i< list.Count;i++)
        {
            if(list[i] == null)list.Remove(list[i]);
        }
        if (bouton.isActivate)
        {
            debut(true);
            bouton.isActivate = false;
        }
        //Game system
        if (!timer.timerFinit && list.Count <=0)
        {
            Debug.Log("C'est GAGNE");
            end = true;
            this.gameObject.SetActive(false);
        } else if (timer.timerFinit)
        {
            Debug.Log("C'est loose frérot");
        }
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
