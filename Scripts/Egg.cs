using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Score.score++;
            GameLogic.score++;

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Score.score++;
            GameLogic.score++;
            //Debug.Log("Colide With Player Score is  :" +Score.score);
            Destroy(gameObject);
        }
    }
}
