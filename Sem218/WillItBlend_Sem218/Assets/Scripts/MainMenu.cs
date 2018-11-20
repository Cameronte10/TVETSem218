using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public Text lastScore;
    public int score;
	// Use this for initialization
	void Start () {
        score = PlayerPrefs.GetInt("Score");
        lastScore = GameObject.Find("LastScore").GetComponent<Text>();
        lastScore.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
