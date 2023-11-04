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

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Загрузить сцену "Menu" или выполнить другие действия при окончании здоровья.
            // Пример загрузки сцены:
            UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
        }
        UpdateHealthText();
    }

    public void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Здоровье: " + currentHealth + " / " + maxHealth;
        }
    }
}
