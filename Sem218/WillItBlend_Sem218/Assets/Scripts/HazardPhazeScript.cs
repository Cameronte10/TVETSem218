using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardPhazeScript : MonoBehaviour {
    float timer;
    public MeshRenderer render;
    public BoxCollider collide;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += 1 * Time.deltaTime;
        if (timer >= 3)
        {
            if (render.enabled == true)
            {
                render.enabled = false;
                collide.enabled = false;
                timer = 0;
            }
            else
            {
                render.enabled = true;
                collide.enabled = true;
                timer = 0;
            }
           
        }
	}
}
