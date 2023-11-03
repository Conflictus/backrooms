using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobBehaivour : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    private NavMeshAgent navMeshAgent;
    public AudioSource notice;
    public float range = 5;
    private bool soundPlayed = false; // Флаг, отслеживающий проигрывание звука

    private void Start()
    {
        // Получаем компонент NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();
        notice = GetComponent<AudioSource>();
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
        if (!soundPlayed && Vector3.Distance(player.position, transform.position) <= range)
        {
            soundPlayed = true; // Помечаем, что звук был проигран
            notice.Play();
            navMeshAgent.SetDestination(player.position);
            print("sound");
        }
    }
}

