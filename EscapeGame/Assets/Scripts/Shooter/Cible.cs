using UnityEngine;

public class Cible : MonoBehaviour
{

    public int pointDeVie = 100;
    public bool isDestroy = false;

    private void Start()
    {
        pointDeVie = 100;
    }
    public void takeDamage(int damage)
    {
        pointDeVie -= damage;
        if (pointDeVie <= 0)
        {
            deSpawn();
        }
    }
    public void deSpawn()
    {
        foreach (Renderer rend in this.gameObject.GetComponentsInChildren<Renderer>())
        {
            rend.enabled = false;
        }
        isDestroy = true;
    }
    public void reSpawn()
    {
        foreach (Renderer rend in this.gameObject.GetComponentsInChildren<Renderer>())
        {
            rend.enabled = true;
        }
        isDestroy = false;
    }
}
