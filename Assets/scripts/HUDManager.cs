using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Добавьте это пространство имен для работы с UI элементами
using TMPro; // Добавьте это пространство имен для работы с TextMeshPro

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI progressText; // Ссылка на TextMeshPro текстовое поле для отображения прогресса

    // В этом методе можно обновлять текст в HUD
    public void UpdateProgress(int currentProgress, int totalProgress)
    {
        progressText.text = "Надо собрать алмазы прогресс: " + currentProgress + "/" + totalProgress;
    }
}
