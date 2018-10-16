using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour
{
    public bool chasing;
    public bool falling;
    public Transform target;
    public Rigidbody rb;
    public float speed;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(chasing == true)
        {
            speed = 1;
            transform.LookAt(target);
            rb.AddForce(transform.forward * speed);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
