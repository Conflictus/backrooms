using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAndDestroy : MonoBehaviour
{
    // Переменная для хранения ссылки на другой префаб, с которым вы хотите сравнивать координаты.
    public GameObject otherPrefab;

    private void Start()
    {
        // Получаем координаты текущего префаба
        Vector3 currentPosition = transform.position;

        // Получаем координаты другого префаба
        Vector3 otherPosition = otherPrefab.transform.position;

        // Проверяем, совпадают ли координаты
        if (currentPosition == otherPosition)
        {
            // Если координаты совпадают, уничтожаем текущий префаб
            Destroy(gameObject);
        }
    }
}
