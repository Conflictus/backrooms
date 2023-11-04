using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private CharacterController m_controller;
    public float m_speed = 0.7f;
    private int health = 100; // Текущее здоровье игрока
    private int maxHealth = 100; // Максимальное здоровье игрока
    HealthManager healthManager; // Ссылка на компонент управления здоровьем

    private void Awake()
    {
        m_controller = GetComponent<CharacterController>();
        healthManager = GetComponent<HealthManager>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move_dir = (horizontal * transform.right) + (vertical * transform.forward);
        move_dir *= m_speed;
        m_controller.Move(move_dir * m_speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Предполагается, что вражеские объекты имеют тег "Enemy"
        {
            healthManager.TakeDamage(15); // Игрок теряет 15 здоровья при столкновении с врагом
        }
    }
}
    

