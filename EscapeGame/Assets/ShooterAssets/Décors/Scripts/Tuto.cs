using UnityEngine;
using System.Collections.Generic;

public class Tuto : MonoBehaviour
{
    public List<Cible> list;
   // public bool start = false;

    public GameObject valide;
    public GameObject nonValide;

    int cptDestroy;

    private void Start()
    {
        foreach (Cible cible in this.gameObject.GetComponentsInChildren<Cible>())
        {
            list.Add(cible);
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].isDestroy) cptDestroy++;
        }
        if (cptDestroy >= list.Count)
        {
            valide.SetActive(true);
            nonValide.SetActive(false);
        }
        cptDestroy = 0;
    }
}
