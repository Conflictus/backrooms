using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;


    public TMP_Text healthText; // Ссылка на текстовый элемент для отображения здоровья
     player_movement pm;

    private void Start()
    {
        currentHealth = maxHealth;
        pm = GetComponent<player_movement>();
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        pm.health -= damage;
        print("change health");
        healthText.text = "Здоровье: " + pm.health + " / " + maxHealth;
        if (pm.health <= 0)
        {
            currentHealth = 0;
            // Загрузить сцену "Menu" или выполнить другие действия при окончании здоровья.
            // Пример загрузки сцены:
            UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
        }
      
    }

    public void UpdateHealthText()
    {


        if (healthText != null)
        {
            healthText.text = "Здоровье: " + 100 + " / " + maxHealth;
        }
    }
}
