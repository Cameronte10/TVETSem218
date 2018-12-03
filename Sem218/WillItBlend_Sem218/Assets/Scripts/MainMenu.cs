using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public Text lastScore;
    public Text textHighScore;
    public Text moneyText;
    public int score;
    public int highScore;
    public int money;
    public string skins;
	// Use this for initialization
	void Start () {
        money = PlayerPrefs.GetInt("money");
        score = PlayerPrefs.GetInt("Score");
        highScore = PlayerPrefs.GetInt("highScore");
        lastScore = GameObject.Find("LastScore").GetComponent<Text>();
        moneyText = GameObject.Find("Money").GetComponent<Text>();
        lastScore.text = "Score: " + score;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        textHighScore = GameObject.Find("HighScore").GetComponent<Text>();
        textHighScore.text = "HighScore: " + highScore;
        moneyText.text = "Points: " + money;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
