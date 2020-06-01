using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetPlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        float hrz = Input.GetAxis("Horizontal");
        float vrt = Input.GetAxis("Vertical");

        Vector3 mvmnt = new Vector3(hrz * speed,0 , vrt * speed);
        rb.AddForce(mvmnt);
    }
}
