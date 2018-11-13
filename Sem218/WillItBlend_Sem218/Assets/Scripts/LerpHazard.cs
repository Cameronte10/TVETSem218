﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpHazard : MonoBehaviour
{

    public Transform startMarker;
    public Transform endMarker;
    public bool reverse;


    // Movement speed in units/sec.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Follows the target position like with a spring
    void Update()
    {
        if (reverse == false)
        {
            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        }
        else if (reverse == true)
        {
            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed = current distance divided by total distance.
            float fracJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(endMarker.position, startMarker.position, fracJourney);
        }

        if (transform.position == endMarker.transform.position)
        {
            reverse = true;
            startTime = Time.time;
            journeyLength = Vector3.Distance(endMarker.position, startMarker.position);
        }

        if (reverse == true && transform.position == startMarker.transform.position)
        {
            reverse = false;
            startTime = Time.time;
            journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        }
    }
}
