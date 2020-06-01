using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour
{
    public Transform targetObj;
    public Rigidbody2D targetRb;
    private GameObject player;

    public float speed = 2f;
    public float distance = 2f;
    public int range = 10;

    public bool isTargetActive = false;
    public bool isTargetMoving = false;

    
 



    void Start()
    {
        targetObj = GetComponent<Transform>();
        targetRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
          
    }


    void Update()
    {
        if(isTargetActive == false) { 

        PlayerInDistanceOfTarget();
        
            

        }

        if (isTargetMoving && isTargetActive)
        {

            TargetMovement();
        }

    }

    //Check if distance between player and target
    public void PlayerInDistanceOfTarget()
    {

        Vector3 targetPos = targetObj.position;
        Vector3 playerPos = player.transform.position;

        if (Vector3.Distance(targetPos, playerPos) < range)
        {
          ActivateTarget();

        }


    }

    
    //Rotates Target up and sets boolean to true
    public void ActivateTarget()
    {
        transform.Rotate(Vector3.right * 90 );

        isTargetActive = true;

        

    }

    //Moves target between two points
    public void TargetMovement()
    {
        if (isTargetActive)
        {
            Debug.Log("target Move");

            targetObj.position = new Vector3(Mathf.PingPong(Time.time * speed, distance ), transform.position.y, transform.position.z);

        }

    }
}
