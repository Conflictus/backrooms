using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAndDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        // Получаем все объекты с тегом "wall1" в сцене
        GameObject[] wallObjects = GameObject.FindGameObjectsWithTag("wall1");

        // Проходим по каждому объекту с тегом "wall1"
        foreach (GameObject wallObject in wallObjects)
        {
            // Проверяем совпадение координат текущего объекта с объектами "wall1"
            if (transform.position == wallObject.transform.position)
            {
                // Если координаты совпадают, удаляем текущий объект
                Destroy(gameObject);
                return; // Завершаем поиск, так как объект уже удален
            }
        }
    }
}
