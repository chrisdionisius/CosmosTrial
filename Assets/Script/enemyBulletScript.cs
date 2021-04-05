using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyBulletScript : MonoBehaviour
{
    public float speed = 4f;
    public Rigidbody2D rb;

    void Start(){
        rb.velocity = -transform.up * speed;
    }

    void  OnBecameInvisible (){
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hit){
        if (hit.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
