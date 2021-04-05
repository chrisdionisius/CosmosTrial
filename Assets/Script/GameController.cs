using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    private int score;
    public GameObject gate;
    public BGScroll background;
    public spawnScript spawn;

    void Start (){
        score = 0;
        UpdateScore (); 
        if (gate.activeInHierarchy){
             gate.SetActive(false);
        }
         StartCoroutine(LateCall());
    }

    public void AddScore (){
        score += 1;
        UpdateScore ();
    }

    void UpdateScore (){
        scoreText.text = "Score: " + score;
    }

    IEnumerator LateCall(){
         yield return new WaitForSeconds(5f);
         background.stopMovement();
         gate.SetActive(true);
         spawn.endGame();
     }

}
