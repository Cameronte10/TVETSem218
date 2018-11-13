using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRandom : MonoBehaviour {
    public int randomX;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        randomX = Random.Range(5, 50);
        transform.Rotate(Vector3.right * Time.deltaTime * randomX);
        randomX = Random.Range(5, 50);
        transform.Rotate(Vector3.up * Time.deltaTime * randomX);
        randomX = Random.Range(5, 50);
        transform.Rotate(Vector3.forward * Time.deltaTime * randomX);
    }
}
