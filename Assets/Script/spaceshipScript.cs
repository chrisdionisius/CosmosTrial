using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spaceshipScript : MonoBehaviour{
    public float speed = 10;
    private Rigidbody2D rigidBody2D;
    public GameObject bullet;

    void Awake(){
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        float xSpeed = xMove * speed;
        float ySpeed = yMove * speed;
        Vector2 newVelocity = new Vector2(xSpeed, ySpeed);
        rigidBody2D.velocity = newVelocity;
    }

    void  Update (){ 
        if (Input.GetKeyDown("space")){
            InvokeRepeating("shoot", 0.01f, 0.1f);
        }
        else if(Input.GetKeyUp("space")){
            CancelInvoke("shoot");
        }
    }

    void shoot(){
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
