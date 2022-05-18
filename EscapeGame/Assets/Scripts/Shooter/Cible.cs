using UnityEngine;

public class Cible : MonoBehaviour
{

    public int pointDeVie = 100;

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
        Destroy(this.gameObject);
    }
}
