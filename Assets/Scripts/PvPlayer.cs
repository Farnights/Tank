using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PvPlayer : MonoBehaviour
{
    [SerializeField] private GameObject tank;
    [SerializeField] private TMP_Text scoreText;
    private float maxHealth = 10f;
    private float minHealth;
    [SerializeField] private Image healthBarImage;
    
    private void UpdateScore()
    {
        tank.GetComponent<Tank>().pv = Mathf.Clamp(tank.GetComponent<Tank>().pv, minHealth, maxHealth);
        scoreText.text = tank.GetComponent<Tank>().pv + " / " + maxHealth;
        healthBarImage.fillAmount = tank.GetComponent<Tank>().pv / maxHealth;
    }

    private void Update()
    {
        UpdateScore();
    }
}