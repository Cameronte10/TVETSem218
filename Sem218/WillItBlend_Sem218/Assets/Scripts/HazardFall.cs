using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardFall : MonoBehaviour {
    public Vector3 startPos;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Boundary"))
        {
            transform.position = startPos;
        }
    }
}

