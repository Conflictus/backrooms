using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

class DiamondCollector : MonoBehaviour
{
    public static int collectedDiamonds = 0;
    scenechanger sceneChanger;
    
    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player")) // Предполагается, что у игрока установлен тег "Player"
    {
        Destroy(gameObject);
        collectedDiamonds++;

        if (collectedDiamonds >= 4)
        {
            sceneChanger.currentProgress += 1;
            sceneChanger.UpdateGameButtonAvailability();
            UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
            
        }
    }
}

    // Можно добавить дополнительные функции для сохранения прогресса уровня
    private void SaveLevelProgress()
    {
        // Реализуйте сохранение данных о прохождении уровня здесь
    }
}