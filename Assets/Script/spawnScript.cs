using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour {
public GameObject asteroid;

// Variable to know how fast we should create new enemies
public float spawnTime = 2;
public Renderer rd; 

void  Start (){
    // Call the 'addEnemy' function in 0 second
    // Then every 'spawnTime' seconds
    InvokeRepeating("addAsteroid", 0, spawnTime);
}

// New function to spawn an enemy
void  addAsteroid (){
    // It's: (position of the center) minus (half the width)
    float x1 = transform.position.x - rd.bounds.size.x/2;

    // Same for the right edge
    float x2 = transform.position.x + rd.bounds.size.x/2;

    // Randomly pick a point within the spawn object
    Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

    // Create an enemy at the 'spawnPoint' position
    Instantiate(asteroid, spawnPoint, Quaternion.identity);
} 

public void endGame(){
    Debug.Log("endgame");
    CancelInvoke("addAsteroid");
}

}
