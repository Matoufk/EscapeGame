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
            //Debug.Log("Pas de cam frerot");
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

    void onHit(Vector3 pos, Vector3 normal)
    {
        GameObject hitEffect = Instantiate(this.gameObject.GetComponentInChildren<Camera>().GetComponent<CameraScript>().graphics.hitEffectPrefab, pos, Quaternion.LookRotation(normal));
        Destroy(hitEffect,2f);
    }
    private void Shoot()
    {
        RaycastHit hit;
        this.gameObject.GetComponentInChildren<Camera>().GetComponent<CameraScript>().graphics.muzzleFlash.Play();
        

        if(Physics.Raycast(cam.transform.position,cam.transform.forward,out hit, weapon.range, mask))
        {
            //Debug.Log("Object touché : " + hit.collider.name);
            Cible cibleTarget = hit.collider.GetComponent<Cible>();
            if(cibleTarget != null)cibleTarget.takeDamage(weapon.damage);
            onHit(hit.point, hit.normal);
        }
    }
}
