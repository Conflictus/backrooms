using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiamondCollector : MonoBehaviour
{
    player_movement PM;
    public int levelIndex; // Установите номер уровня в инспекторе Unity
    public static int collectedDiamonds = 0;
    void Start() {
        collectedDiamonds = 0;
        PM = FindObjectOfType<player_movement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Сбор алмаза
            Destroy(gameObject);
            collectedDiamonds++;

            if (collectedDiamonds >= 4)
            {
                // Получаем ссылку на объект "SceneChanger" в сцене
                          
                    if (PM.level!= 9) {
                    PM.level++;
                    }
                    PlayerPrefs.SetInt("PlayerLevel", PM.level);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("menu");
                    
            }
        }
    }
}