using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Camera cam;
    public PlayerWeapon weapon;

    public CameraScript cameraScript;
    
    public bool gunEquip = false;

    [SerializeField]
    private LayerMask mask;

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
        gunEquip = cameraScript.asGun;
        if (gunEquip && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    private void Shoot()
    {
        RaycastHit hit;
        this.gameObject.GetComponentInChildren<Camera>().GetComponent<CameraScript>().graphics.muzzleFlash.Play();

        if(Physics.Raycast(cam.transform.position,cam.transform.forward,out hit, weapon.range, mask))
        {
            Debug.Log("Object touché : " + hit.collider.name);
            Cible cibleTarget = hit.collider.GetComponent<Cible>();
            if(cibleTarget != null)cibleTarget.takeDamage(weapon.damage);
        }
    }
}
