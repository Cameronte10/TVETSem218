using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonLink : MonoBehaviour {
    public static MenuButtonLink instance;
    Button thisButton;
    public int list; //PlayButton=0, Picker=1, NewColour=2
    public ColourManager colourManager;
	// Use this for initialization
	void Start () {
        colourManager = GameObject.Find("ColourManager").GetComponent<ColourManager>();
        thisButton = GetComponent<Button>();
        if (list == 0)
        {
            thisButton.onClick.AddListener(colourManager.Clicked);
        }
        if (list == 1)
        {
            thisButton.onClick.AddListener(colourManager.ColourClicked);
        }
        if (list == 2)
        {
            thisButton.onClick.AddListener(colourManager.BuyColour);
        }

    }
    private void Awake()
    {
        if (gameObject.name.Equals("Picker"))
        {
            instance = this;
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
