using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int targetScore = 10; // Целевое количество очков, чтобы пройти уровень
    private int currentScore = 0; // Текущее количество очков
    private bool levelCompleted = false; // Флаг, который отслеживает завершение уровня

    [SerializeField] private GameObject targetPrefab; // Префаб, который игрок должен касаться

    private void Start()
    {
        // Задаем начальные значения
        currentScore = 0;
        levelCompleted = false;
    }

    private void Update()
    {
        // Если уровень не завершен
        if (!levelCompleted)
        {
            // Проверяем, касается ли игрок цели
            if (Input.GetMouseButtonDown(0)) // Или любой другой метод проверки касания
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == targetPrefab)
                    {
                        // Игрок коснулся цели, добавляем очко
                        currentScore++;

                        // Проверяем, достиг ли игрок целевого количества очков
                        if (currentScore >= targetScore)
                        {
                            // Уровень завершен
                            levelCompleted = true;

                            // Здесь вы можете вызвать функцию сохранения данных о прохождении уровня
                            SaveLevelProgress();

                            // Загружаем сцену меню
                            SceneManager.LoadScene("menu");
                        }
                    }
                }
            }
        }
    }

    private void SaveLevelProgress()
    {
        // Здесь вы можете реализовать сохранение информации о прохождении уровня, например, с использованием PlayerPrefs
        // Пример сохранения текущего уровня
        PlayerPrefs.SetInt("Level1Completed", 1); // Устанавливаем флаг, что первый уровень пройден
        PlayerPrefs.Save(); // Сохраняем изменения

        // В реальном проекте вам, возможно, потребуется более сложная система сохранения данных.
    }
}
