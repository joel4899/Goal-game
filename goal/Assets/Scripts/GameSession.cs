using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSession : MonoBehaviour
{
    int score = 0;

    void Awake()
    {
        SetUpSingleton();
    }


    private void SetUpSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
      
    }


    public void AddToScore(int scoreValue)
    {
        
        score += scoreValue;
        print(score);
        if (score >= 20)
        {

            SceneManager.LoadScene("Win");
        }
    }

    
}
