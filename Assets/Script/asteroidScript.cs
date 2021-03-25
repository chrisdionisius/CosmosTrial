using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidScript : MonoBehaviour {
public int speed = -5;
public Rigidbody2D rb;

// Function called when the enemy is created
void  Start (){
    rb.velocity = transform.up * speed;
    rb.angularVelocity = Random.Range(-200, 200);
}

// Function called when the object goes out of the screen
void  OnBecameInvisible (){
    Destroy(gameObject);
} 

 
}
