using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 1;
    public Rigidbody2D rb;
    public GameObject bullet;

// Function called when the enemy is created
    void  Start (){
        rb.velocity = -transform.up * speed;
        InvokeRepeating("shoot", 0.01f, 2f);
    }

    // Function called when the object goes out of the screen
    void  OnBecameInvisible (){
        Destroy(gameObject);
    }
    
    void shoot(){
        Instantiate(bullet, transform.position, Quaternion.identity);
    } 
}
