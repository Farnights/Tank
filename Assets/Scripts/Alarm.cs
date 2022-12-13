using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{

    [SerializeField] private Transform AlarmSpawnPosition;
    [SerializeField] private Transform AlarmEndPosition;
    private float direction = 1f;
    void Update()
    {
        transform.Translate(direction*Vector3.left*Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AlarmEndPosition"))
        {
            direction = -direction;
        }
    }
}
