using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float damage;
    public float range;
    public float fireRate;
    public float maxAmmo;
    public float ammo;
    public float reloadTime = 2;
    public bool isReloading;

    private Camera playerCam;
    private GameObject hitObject;


    // Start is called before the first frame update
    void Start()
    {
        playerCam = GetComponent<Camera>();
        isReloading = false;
        maxAmmo = 15;
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if(ammo > 0 && !isReloading)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Shoot();

            }
        }

        if(Input.GetButtonDown("Reload") && !isReloading)
        {

            StartCoroutine(Reload());

        }

    }

    void Shoot()
    {

        Debug.Log("PewPew");

        Vector3 tDirection = playerCam.transform.forward;

        ammo--;

        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, tDirection, out hit))
        {
            hitObject = hit.transform.gameObject;

            Debug.Log(hitObject);

            if (hitObject.CompareTag("Enemy"))
            {
                Destroy(hitObject);
            }
        }
    }

    IEnumerator Reload()
    {

        Debug.Log("Reloading...");

        ammo = maxAmmo;
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        Debug.Log("Finished reload");
        isReloading = false;
    }
}
