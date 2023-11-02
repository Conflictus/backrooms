using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobBehaivour : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        // Получаем компонент NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Убедитесь, что у игрока также есть компонент NavMeshAgent
        if (player == null || player.GetComponent<NavMeshAgent>() == null)
        {
            Debug.LogError("Player does not have a NavMeshAgent component.");
            enabled = false; // Отключаем этот скрипт
        }
    }

    private void Update()
    {
        // Проверяем, есть ли игрок
        if (player != null)
        {
            // Устанавливаем позицию, к которой двигаться - позиция игрока
            navMeshAgent.SetDestination(player.position);
        }
    }
}

