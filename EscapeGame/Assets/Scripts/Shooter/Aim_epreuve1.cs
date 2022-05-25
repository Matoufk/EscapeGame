using System.Collections.Generic;
using UnityEngine;

public class Aim_epreuve1 : MonoBehaviour
{
    public List<Cible> list;
    public bool start = false;

    public BoutonStart bouton;
    public bool end = false;
    public Timer_script timer;

    private int cptDestroy;


    public Animator doorR;
    public Animator doorL;

    public AudioSource win;
    public AudioSource loose;
    private void Start()
    {
        foreach (Cible cible in this.gameObject.GetComponentsInChildren<Cible>())
        {
            list.Add(cible);
        }
        debut(start);
    }
    void FixedUpdate()
    {
        if (!end)
        {
            if (start)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].isDestroy) cptDestroy++;
                }
                if (cptDestroy >= list.Count)
                {
                    Debug.Log("C'est GAGNE");
                    end = true;
                    doorL.SetBool("isOpen", true);
                    doorR.SetBool("isOpen",true);
                    win.Play();
                    timer.timerActive = false;
                    timer.valide();
                    //this.gameObject.SetActive(false);
                    cptDestroy = 0;
                }
                //Game system
                if (timer.timerFinit)
                {
                    Debug.Log("C'est loose frérot");
                    loose.Play();
                    start = false;
                    debut(start);
                }
            }
            cptDestroy = 0;
            if (bouton.isActivate)
            {
                start = !start;
                debut(start);
                bouton.isActivate = false;
            }
        }

    }
    void debut(bool start)
    {
        if (start)
        {
            foreach (Cible cible in list)
            {
                cible.reSpawn();
                timer.gameObject.SetActive(true);
                timer.currentTime = 30f;
                timer.timerActive = true;
                timer.timerFinit = false;
            }
        }
        if (!start)
        {
            foreach (Cible cible in list)
            {
                cible.deSpawn();
                timer.gameObject.SetActive(false);
            }
        }
    }
}
