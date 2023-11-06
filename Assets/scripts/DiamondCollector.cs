using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiamondCollector : MonoBehaviour
{
    public int levelIndex; // Установите номер уровня в инспекторе Unity
    public static int collectedDiamonds = 0;
    void Start() {
        collectedDiamonds = 0;
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
                scenechanger sceneChanger = GameObject.Find("SceneChanger").GetComponent<scenechanger>();

                if (sceneChanger != null)
                {
                    
                    SceneManager.LoadScene("menu");
                }
            }
        }
    }
}