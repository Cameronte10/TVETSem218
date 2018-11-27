using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardProperFall : MonoBehaviour {
    public float verticalSpeed;
    public GameManagerScript instance;
    public float horizontalSpeed;
    public Rigidbody rb;
	// Use this for initialization
	void Start () {
        instance = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(new Vector3(horizontalSpeed *  Time.deltaTime, verticalSpeed * Time.deltaTime, 0));
        rb.AddForce(horizontalSpeed, verticalSpeed, 0);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    void onDestroy()
    {
        transform.parent.GetComponent<Parent>().CheckForDestroy();
    }
}
