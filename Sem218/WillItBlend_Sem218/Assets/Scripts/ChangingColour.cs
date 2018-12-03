using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangingColour : MonoBehaviour {

    // Use this for initialization
    public Light li;
    public Color c;
    public Color32 green = new Color32(74, 255, 83, 255);
    public Color32 blue = new Color32(74, 166, 255, 255);
    public Color32 red = new Color32(255, 86, 73, 255);
    public string skin;
	void Start () {
        skin = PlayerPrefs.GetString("skin");
	}
	
	// Update is called once per frame
	void Update () {
        if (skin == "Red")
        {
            c = red;
            li.color = c;
        }
        if (skin == "Green")
        {
            c = green;
            li.color = c;
        }
        if (skin == "Blue")
        {
            c = blue;
            li.color = c;
        }
    }
}
