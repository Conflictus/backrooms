using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiamondCollector : MonoBehaviour
{
    public int targetScore = 4; // Целевое количество алмазов
    private static int diamondCount = 0; // Счетчик собранных алмазов
    public HUDManager hudManager; // Ссылка на компонент HUDManager

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Предполагается, что игрок имеет тег "Player"
        {
            // Удалите алмаз после сбора
            Destroy(gameObject);

            // Увеличиваем счетчик собранных алмазов
            diamondCount++;

            // Проверяем, достиг ли игрок целевого количества очков
            if (diamondCount >= targetScore)
            {
                // Уровень завершен
                // Здесь вы можете вызвать функцию сохранения данных о прохождении уровня
                SaveLevelProgress();
            }

            // Обновляем текст в HUD
            hudManager.UpdateProgress(diamondCount, targetScore);
        }
    }

    // Дополнительные функции могут быть добавлены для сохранения данных о прохождении уровня и другой логики, связанной с прохождением уровня.
    private void SaveLevelProgress()
    {
        // Реализуйте сохранение данных о прохождении уровня здесь
    }
}