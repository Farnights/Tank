using System.Collections.Generic;
using UnityEngine;

public class Ammunitions : MonoBehaviour
{
    [SerializeField] private GameObject tank;
    [SerializeField] private GameObject bulletImage;
    [SerializeField] private Transform canvas;
    private float nbBullets;
    public List<GameObject> listImage = new List<GameObject>();
    public GameObject[] listImage2 = new GameObject[11];

    private void Awake()
    {
        nbBullets = tank.GetComponent<Tank>().nbBullets;
        listImage.Clear();
        for (int i = 1; i < (int)nbBullets+1; i++)
        {
            //listImage2[i] = Instantiate(bulletImage, new Vector3(i * 25f, 25f, 0f), Quaternion.identity, canvas);
            listImage.Add(Instantiate(bulletImage, new Vector3(i * 25f, 25f, 0f), Quaternion.identity, canvas));
            Debug.Log(listImage.Count);
        }
    }
}