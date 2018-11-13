using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardFall : MonoBehaviour {
    //public Vector3 startPos;
    //public float horizontalMove;
    //public float verticalMove;
    public Transform target;
    public List<Transform> spawns;
    public Transform[] spawnlist;
    public Rigidbody rb;
    public float speed;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 7; i++)
        {
            spawns.Add(GameObject.Find("Spawnpoint"+i).GetComponent<Transform>());
        }
        //startPos = transform.position;
        target = GameObject.Find("Player").GetComponent<Transform>();
        Spawn();
        rb = gameObject.GetComponent<Rigidbody>();
	}
	void Spawn()
    {
        int i = Random.Range(0, spawns.Count);
        transform.position = spawns[i].position;
        transform.LookAt(target);
    }
	// Update is called once per frame
	void Update () {
        //transform.Translate(new Vector3(horizontalMove, verticalMove, 0));
        //rb.AddForce(Vector3.up * speed);
        transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
	}
    private void OnTriggerEnter(Collider collision)
    {
       

        if (collision.gameObject.CompareTag("Boundary"))
        {
            Spawn();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("dodge");
         
        }
    }
}

