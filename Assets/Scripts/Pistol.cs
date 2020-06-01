using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float damage;
    public float range;
    public float fireRate;
    public float ammo;

    private Camera playerCam;
    private GameObject hitObject;


    // Start is called before the first frame update
    void Start()
    {
        playerCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ammo > 0)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Shoot();
                Debug.Log("PewPew");
            }
        }
    }

    void Shoot()
    {
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
}
