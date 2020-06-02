using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float damage;
    public float range;
    public float fireRate = 2;
    public float nextTimeToFire = 0;
    public float maxAmmo;
    public float ammo;
    public float reloadTime = 2;
    public bool isReloading;
    public bool isShooting;

    private Camera playerCam;
    private GameObject hitObject;

    AudioSource gunSound;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        playerCam = GetComponent<Camera>();
        gunSound = GetComponentInChildren<AudioSource>();
        isReloading = false;
        maxAmmo = 15;
        ammo = maxAmmo;

    }

    // Update is called once per frame
    void Update()
    {

        if(ammo > 0 && !isReloading && !isShooting)
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

        isShooting = true;

        Debug.Log("PewPew");

        gunSound.Play();

        animator.SetTrigger("Shoot");

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

        isShooting = false;

        animator.SetTrigger("Shoot");
    }

    IEnumerator Reload()
    {

        Debug.Log("Reloading...");

        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        ammo = maxAmmo;
        Debug.Log("Finished reload");
        isReloading = false;
    }
}
