using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public Text lastScore;
    public Text textHighScore;
    public int score;
    public int highScore;
    public string skins;
	// Use this for initialization
	void Start () {
        score = PlayerPrefs.GetInt("Score");
        highScore = PlayerPrefs.GetInt("highScore");
        lastScore = GameObject.Find("LastScore").GetComponent<Text>();
        lastScore.text = "Score: " + score;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        textHighScore = GameObject.Find("HighScore").GetComponent<Text>();
        textHighScore.text = "HighScore: " + highScore;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
