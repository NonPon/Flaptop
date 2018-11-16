using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text scoreDisplay;
    private float score = 0.0f;

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;

    public Text scoreText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (score >=scoreToNextLevel )
            LevelUp();


        score += Time.deltaTime * difficultyLevel;
        scoreDisplay.text = ((int)score).ToString();
	}

    void LevelUp()
    {
        if(difficultyLevel == maxDifficultyLevel)
            return;

        scoreToNextLevel *= 2;
        difficultyLevel++;

        GetComponent<Player>().SetSpeed (difficultyLevel);

        Debug.Log(difficultyLevel);
    }

 //   void OnTriggerEnter(Collider other)
 //   {
 //       if (other.CompareTag("Obstacle"))
 //       {
 //           score++;
 //           scoreDisplay.text = score.ToString();
 //       }
//    }
}
