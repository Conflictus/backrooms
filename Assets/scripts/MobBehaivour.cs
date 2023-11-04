using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobBehavior : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    private NavMeshAgent navMeshAgent;
    private AudioSource oneShotAudio;
    private AudioSource loopedAudio;
    public AudioClip oneShotSound; // Аудиоклип для однократного воспроизведения
    public AudioClip loopingSound; // Аудиоклип для звука с повторением
    public float range = 5;

    private bool isPlayingOneShot = false; // Флаг для однократного звука
    private bool isPlayingLooped = false;  // Флаг для звука с повторением

    private void Start()
    {
        // Получаем компонент NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Добавляем компоненты AudioSource для однократного и зацикленного звуков
        oneShotAudio = gameObject.AddComponent<AudioSource>();
        oneShotAudio.clip = oneShotSound;

        loopedAudio = gameObject.AddComponent<AudioSource>();
        loopedAudio.clip = loopingSound;
        loopedAudio.loop = true; // Устанавливаем зацикливание

        // Убедитесь, что у игрока также есть компонент NavMeshAgent
        if (player == null || player.GetComponent<NavMeshAgent>() == null)
        {
            Debug.LogError("Player does not have a NavMeshAgent component.");
            enabled = false; // Отключаем этот скрипт
        }
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= range)
        {
            navMeshAgent.SetDestination(player.position);

            if (!isPlayingOneShot)
            {
                oneShotAudio.Play();
                isPlayingOneShot = true; // Устанавливаем флаг в true, чтобы не воспроизводить однократный звук снова
            }

            if (!isPlayingLooped)
            {
                loopedAudio.Play();
                isPlayingLooped = true; // Устанавливаем флаг в true, чтобы не воспроизводить зацикленный звук снова
            }
        }
        else
        {
            if (isPlayingOneShot)
            {
                oneShotAudio.Stop();
                isPlayingOneShot = false;
            }

            if (isPlayingLooped)
            {
                loopedAudio.Stop();
                isPlayingLooped = false;
            }
        }
    }
}