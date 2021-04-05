using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletScript : MonoBehaviour {
    
    public float speed = 10f;
    public Rigidbody2D rb;
    private GameController gameController;
    public GameObject ExplotionAnimation;

    void Start(){
        rb.velocity = transform.up * speed;
        GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if (gameController == null)
        {
            Debug.Log ("Cannot find 'GameController' script");
        }
    }
    void  OnBecameInvisible (){
        Destroy(gameObject);
    } 
    void OnTriggerEnter2D(Collider2D hit){
        if (hit.CompareTag("asteroid")){
            Destroy(this.gameObject);
            Destroy(hit.gameObject);
            PlayExplosion();
            gameController.AddScore();
        }
        if (hit.CompareTag("Enemy")){
            Destroy(this.gameObject);
            Destroy(hit.gameObject);
            PlayExplosion();
            gameController.AddScore();
        }
        if (hit.CompareTag("EnemyBullet")){
            Destroy(this.gameObject);
            Destroy(hit.gameObject);
            PlayExplosion();
        }
    }

    void PlayExplosion(){
        GameObject explosion = (GameObject)Instantiate(ExplotionAnimation);
        explosion.transform.position = transform.position;
    }
}
