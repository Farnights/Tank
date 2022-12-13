using System;
using UnityEngine;

public class Turret : Base_Controller
{
    [SerializeField] private GameObject turretTarget;
    [SerializeField] private float detectionRange = 5f;
    
    
    private void Update()
    {
        RotateToTarget(turretTarget.transform.position);
        if (CheckTargetDistance())
        {
            Fire();
        }

        if (CheckAlarm())
        {
            Fire();
        }
    }

    private bool CheckTargetDistance()
    {
        if (Physics.Raycast(bulletSpawnPosition.position, bulletSpawnPosition.up, out RaycastHit hit, detectionRange))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            UpdatePv();
        }
    }

    public bool CheckAlarm()
    {
        RaycastHit hitTrap;
        if (Physics.Raycast(alarmSpawnPosition.position, alarmSpawnPosition.forward, out hitTrap, 10f))
        {
            if (hitTrap.collider.gameObject.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
}