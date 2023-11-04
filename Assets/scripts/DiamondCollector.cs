using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DiamondCollector : MonoBehaviour
{
    private int collectedDiamonds = 0;
    public TextMeshProUGUI diamondsText;
 // Ссылка на компонент TextMeshPro в инспекторе

    private void Start()
    {
        UpdateDiamondsText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Предполагается, что у игрока установлен тег "Player"
        {
            // Удалите алмаз после сбора
            Destroy(gameObject);
            collectedDiamonds++;

            UpdateDiamondsText();

            if (collectedDiamonds >= 4)
            {
                // Вы собрали 4 алмаза, переключение на сцену меню
                // Замените "MenuScene" на имя вашей сцены меню.
                UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
            }
        }
    }

    private void UpdateDiamondsText()
    {
        if (diamondsText != null)
        {
            diamondsText.text = "Алмазы: " + collectedDiamonds.ToString();
        }
    }

    // Можно добавить дополнительные функции для сохранения прогресса уровня
    private void SaveLevelProgress()
    {
        // Реализуйте сохранение данных о прохождении уровня здесь
    }
}