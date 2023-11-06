using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiamondCollector : MonoBehaviour
{
   
    public static int collectedDiamonds = 0;
    void Start() {
        collectedDiamonds = 0;
        PM = FindObjectOfType<player_movement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Сбор алмаза
            Destroy(gameObject);
            collectedDiamonds++;

            if (collectedDiamonds >= 4)
            {
                
                   
                    SceneManager.LoadScene("menu");
                
            }
        }
    }
}