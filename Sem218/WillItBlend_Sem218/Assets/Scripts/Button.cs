﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Button : MonoBehaviour {
    public string skin;
    public bool picker = false;
    public Image image;
	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        skin = PlayerPrefs.GetString("skin");
        if (picker)
        {
            //ColourClicked();
            if (skin == "Red")
            {
                image.color = Color.red;
                

            }
            else if (skin == "Green")
            {
                image.color = Color.green;
                
            }
            else if (skin == "Blue")
            {

                //image.color = new Color(1f / 255f, 1f / 86f, 1f / 73f);
                image.color = Color.blue;
                
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Clicked()
    {
        SceneManager.LoadScene("Fall");
    }

    public void ColourClicked()
    {
        if (skin == "Red")
        {
            image.color = Color.green;
            skin = "Green";
            PlayerPrefs.SetString("skin", "Green");
            
        }
        else if (skin == "Green")
        {
            //image.color = Color.blue;
            image.color = new Color32(74, 166, 255, 255);
            skin = "Blue";
            PlayerPrefs.SetString("skin", "Blue");
        }
        else if (skin == "Blue")
        {
            image.color = new Color32(255, 86, 73, 255);
            image.color = Color.red;
            skin = "Red";
            PlayerPrefs.SetString("skin", "Red");
        }
        else
        {
            skin = "Blue";
            ColourClicked();
        }
    }
}
