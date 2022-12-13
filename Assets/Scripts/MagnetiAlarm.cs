using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetiAlarm : Base_Controller

{
    [SerializeField] private GameObject Drone;
    [SerializeField] private Transform StartMarker;
    [SerializeField] private Transform EndMarker;
    [SerializeField] private float startTime;
    [SerializeField] private float journeyLength;
    private bool isPatrolActive = true;
    private void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(StartMarker.position, EndMarker.position);
    }

    void Update()
    {
        if (isPatrolActive)
        {
            transform.Rotate(0f,0.05f,0f);

        }
        
        // float distCovered = (Time.time - startTime) * 1.0f;
        // float fracJourney = distCovered / journeyLength;
        // transform.position = Vector3.Lerp(StartMarker.position,EndMarker.position, fracJourney);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Surveillance"))
        {
            StartCoroutine(Pause());
            
        }
    }
    IEnumerator Pause()
    {
        isPatrolActive = false;

        for (int i = 0; i < 30; i++)
        {
            Drone.transform.Rotate(0f,0.5f,0f);
            yield return new WaitForSeconds(0.02f);
        }
        for (int i = 0; i < 60; i++)
        {
            Drone.transform.Rotate(0f,-0.5f,0f);
            yield return new WaitForSeconds(0.02f);
        }
        for (int i = 0; i < 30; i++)
        {
            Drone.transform.Rotate(0f,0.5f,0f);
            yield return new WaitForSeconds(0.02f);
        }
        isPatrolActive = true;

    }

}
