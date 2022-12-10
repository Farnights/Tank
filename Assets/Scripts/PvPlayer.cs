using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PvPlayer : MonoBehaviour
{
    [SerializeField] private GameObject tank;
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] public float maxHealth = 10f;
    [SerializeField] public float minHealth;
    [SerializeField] public Image healthBarImage;
    
    private void UpdateScore()
    {
        tank.GetComponent<Tank>().pv = Mathf.Clamp(tank.GetComponent<Tank>().pv, minHealth, maxHealth);
        scoreText.text = tank.GetComponent<Tank>().pv + " / " + maxHealth;
        healthBarImage.fillAmount = tank.GetComponent<Tank>().pv / maxHealth;
    }

    public void Update()
    {
        UpdateScore();
    }
}