using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ammunitions : MonoBehaviour
{
    [SerializeField] private GameObject tank;
    [SerializeField] private GameObject bulletImage;
    [SerializeField] private Transform canvas;
    private float nbBullets;
    public List<GameObject> listImage;

    private void Awake()
    {
        nbBullets = tank.GetComponent<Tank>().nbBullets;
        listImage.Clear();
        for (int i = 1; i <= nbBullets; i++)
        {
            listImage.Add(Instantiate(bulletImage, new Vector3(i * 25f, 25f, 0f), Quaternion.identity, canvas));
            //Debug.Log(listImage.Count);
        }
    }
    public void LoseAmmo() 
    {
        Destroy(listImage.Last());
        listImage.RemoveAt(listImage.Count-1);
        //Debug.Log(listImage.Count);
    }
}