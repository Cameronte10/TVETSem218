using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangingColour : MonoBehaviour {

    // Use this for initialization
    public Light li;
    public Color c;
    public string skin;
	void Start () {
        skin = PlayerPrefs.GetString("skin");
	}
	
	// Update is called once per frame
	void Update () {
        if (skin == "Red")
        {
            c = Color.red;
            li.color = c;
        }
        if (skin == "Green")
        {
            c = Color.green;
            li.color = c;
        }
        if (skin == "Blue")
        {
            c = Color.blue;
            li.color = c;
        }
    }
}
