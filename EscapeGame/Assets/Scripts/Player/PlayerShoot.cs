using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera cam;
    public PlayerWeapon weapon;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private string layerLocalPlayerName = "LocalPlayer";

    private void Start()
    {
        if( cam == null)
        {
            Debug.Log("Pas de cam frerot");
            this.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(cam.transform.position,cam.transform.forward,out hit, weapon.range, mask))
        {
            Debug.Log("Object touché : " + hit.collider.name);
        }
    }
}
