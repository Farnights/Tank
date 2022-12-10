using UnityEngine;
using UnityEngine.UI;

public class Ammunitions : MonoBehaviour
{
    [SerializeField] private GameObject tank;
    [SerializeField] private GameObject bulletImage;
    [SerializeField] private Transform canvas;
    private float nbBullets;
    private float maxBullets = 10f;
    private float minBullets;

    private void Start()
    {
        nbBullets = Mathf.Clamp(tank.GetComponent<Tank>().nbBullets, minBullets, maxBullets);
        for (int i = 1; i <= nbBullets; i++)
        {
            Instantiate(bulletImage, new Vector3(i * 25f, 25f, 0f), Quaternion.identity, canvas);
        }
    }

    private void UpdateAmmo()
    {
        
    }
}