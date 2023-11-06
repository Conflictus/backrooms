using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player_movement : MonoBehaviour
{
    private CharacterController m_controller;
    public float m_speed = 0.7f;
    public int health = 100; // Текущее здоровье игрока
    HealthManager healthManager; // Ссылка на компонент управления здоровьем
    public TMP_Text healthText;
    public int level = PlayerPrefs.GetInt("PlayerLevel");
    void Start(){
        Cursor.visible = false;
    }
    private void Awake()
    {
        
        m_controller = GetComponent<CharacterController>();
        healthManager = GetComponent<HealthManager>();
        level++;
        PlayerPrefs.SetInt("PlayerLevel", level);
        PlayerPrefs.Save();
        
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 move_dir = (horizontal * transform.right) + (vertical * transform.forward);
        move_dir *= m_speed;
        m_controller.Move(move_dir * m_speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            health -= 10;
            print(health);
            healthText.text = "Здоровье: " + health + " / " + 100;
            if (health <= 0)
            {
                health = 0;
                // Загрузить сцену "Menu" или выполнить другие действия при окончании здоровья.
                // Пример загрузки сцены:
                UnityEngine.SceneManagement.SceneManager.LoadScene("menu");
            }
             // Игрок теряет 15 здоровья при столкновении с врагом
        }
    }

    void Update() {
        print(level);
    }
}
    

