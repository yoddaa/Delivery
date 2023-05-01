using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameLogic : MonoBehaviour
{
    public Text scoreText, timerText, gameOvetText, highScore;
    public Button playButton;

    public GameObject[] playersToToggle;
    public KeyCode[] toggleKeys;
    public GameObject destroyableObject;
    public static int score = 0;
    public float timeLimit = 30f;
    public GameObject spawnersHolder,musicHolder,sfxHolder;
    public static bool isGameOver = false;
    private float timeRemaining;

    public AudioSource playersAudioSource;
    public AudioClip collectAudioClip;

    
    public Toggle isMusic, isSFX;

    private void Start()
    {
        playButton.gameObject.SetActive(false);
        //spawnerHolder = GetComponent<GameObject>();
        //spawnersHolder.SetActive(true);
        // Start with all players hidden
        foreach (GameObject player in playersToToggle)
        {
            player.SetActive(false);
        }

        // Show the first player by default
        playersToToggle[0].SetActive(true);

        // Start the timer
        timeRemaining = timeLimit;
    }

    private void Update()
    {
        

        if (!isGameOver)
        {
            // Handle player toggling with keys
            for (int i = 0; i < playersToToggle.Length; i++)
            {
                if (Input.GetKeyDown(toggleKeys[i]))
                {
                    ShowPlayer(i);
                }
            }

            // Update the timer
            timeRemaining -= Time.deltaTime;
            timerText.text = timeRemaining.ToString();
            scoreText.text = score.ToString();

            if (timeRemaining <= 0)
            {
                // Time is up, do something here
                gameOvetText.text = "Game Over!!";

                highScore.text = "Collected : " + score.ToString() + " Eggs. :)";
                //Destroy(spawnersHolder);
                spawnersHolder.SetActive(false);
                timeRemaining = 0;
                isGameOver = true;
                //Application.Quit();
                
            }
        }
        else
        {
           playButton.gameObject.SetActive(true);
            //playButton.enabled = true;
            isGameOver = false;
            timerText.text = "Time Ended";
        }
    }

    private void ShowPlayer(int index)
    {
        // Show the player at the given index and hide the rest
        for (int i = 0; i < playersToToggle.Length; i++)
        {
            playersToToggle[i].SetActive(i == index);
        }
    }

  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playersAudioSource.PlayOneShot(collectAudioClip);
            timeRemaining++;
            score++;
            scoreText.text = score.ToString();
            //Debug.Log("Player Col :" + Score.score);
            //Destroy(gameObject);
        }
    }


    private void Reset()
    {
        playButton.gameObject.SetActive(false);
        isGameOver = false;
        playButton.gameObject.SetActive(false);
        timeLimit = 30f;
        score = 0;
        spawnersHolder.SetActive(true);
        highScore.text = "";
        gameOvetText.text = "";
    }
}




/*
 * 
 * In this script, we have public variables for an array of game objects to 
 * toggle, an array of keys to use to toggle the objects, a reference to 
 * the player object, the player's score, and a time limit. 
 * We start with all objects hidden and start the timer in the Start() function.
 * 
 * In the Update() function, we check for key presses and toggle the appropriate 
 * object with the ShowObject() function. We also update the timer and check if time is up.
 * 
 * The ShowObject() function takes an index and shows the game object at
 * that index while hiding the rest.
 * 
 * The OnTriggerEnter() function is called when the player collides with a game object
 * with the "Destroyable" tag. If this happens, we increment the score and destroy the game object.
 * 
 * To use this script, simply attach it to an empty game object in your
 * scene and set the public variables in the Unity Editor. Add the "Destroyable" tag
 * to any game objects you want to be destroyable. The keys to toggle the objects 
 * can be set by adding the KeyCode values to the toggleKeys array.
 * 
 * 

*/