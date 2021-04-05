using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public Image[] spaceshipPlaceholders;
    public Sprite livesOn;
    public Sprite livesOff;
    public int totalLives = 3;
    public GameObject gameOver;

    public GameObject blowAnimation;
    /*public PauseMenu PauseMenu;*/

    void Start()
    {
        gameOver.gameObject.SetActive(false);
        /*PauseMenu = GetComponent<PauseMenu>();*/
    }

    public void OnChangeSpaceShipTotal(int totalLives)
    {
        if (totalLives != 0) {
            for (int i = 0; i < 3; ++i)
            {
                if (i < totalLives)
                    spaceshipPlaceholders[i].sprite = livesOn;
                else
                    spaceshipPlaceholders[i].sprite = livesOff;
            }
        }
        else 
        {
            spaceshipPlaceholders[0].sprite = livesOff;
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0f;
        } 
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("asteroid"))
        {
            totalLives--;
            OnChangeSpaceShipTotal(totalLives);
            Destroy(hit.gameObject);
            PlayExplosion();
        }
        if (hit.CompareTag("Gate"))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void PlayExplosion(){
        GameObject explosion = (GameObject)Instantiate(blowAnimation);
        explosion.transform.position = transform.position;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    /*public void GamePaused()
    {
        if (gameOver.gameObject.setActive(true))
        {
            PauseMenu.pauseMenuUI.setActive(false);
        }
    }*/
}
