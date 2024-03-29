using System.Collections;
using UnityEngine;

public class Base_Controller : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] protected Transform bulletSpawnPosition;
    [SerializeField] private GameObject turretHead;
    [SerializeField] private Transform _transform;
    [SerializeField] public float pv = 10f;
    [SerializeField] public float nbBullets = 10f;
    protected bool isAlreadyFiring;
    [SerializeField] protected Transform alarmSpawnPosition;
    

    protected void UpdatePv()
    {
        pv--;
        if (pv == 0)
        {
            Destroy(gameObject);
        }
    }
    
    protected void Fire()
    {
        if (nbBullets > 0)
        {
            if (!isAlreadyFiring)
            {
                isAlreadyFiring = true;
                StartCoroutine(FireDelay());
            }
        }
    }

    IEnumerator FireDelay()
    {
        nbBullets--;
        Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        yield return new WaitForSeconds(1.5f);
        isAlreadyFiring = false;
    }
    
    protected void RotateToTarget(Vector3 targetPos)
    {
        _transform.position = new Vector3(targetPos.x, turretHead.transform.position.y, targetPos.z);
        turretHead.transform.LookAt(_transform);
    }
    
    
    
}