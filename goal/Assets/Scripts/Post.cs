using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Post : MonoBehaviour
{


    [SerializeField] float goalDuration = 2f;

    [SerializeField] AudioClip gooal;
  
    [SerializeField] [Range(0, 3)] float goalSoundVolume = 1f;

   

    [SerializeField] int scoreValue = 1;


    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        AudioSource.PlayClipAtPoint(gooal, Camera.main.transform.position, goalSoundVolume);
      //  Destroy(, goalDuration);
        FindObjectOfType<GameSession>().AddToScore(scoreValue);

    }

}
