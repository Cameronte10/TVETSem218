using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangingColour : MonoBehaviour {

   
    public Light li;
   
    public ColourManager colourChanger;
  
    public string skin;
	void Start () {
       
        colourChanger = GameObject.Find("ColourManager").GetComponent<ColourManager>();
        Debug.Log(ColourManager.instance.index);
        li.color = ColourManager.instance.colours[colourChanger.index];
        
	}
	
	
	
}
