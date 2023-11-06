using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenechanger : MonoBehaviour
{
    public GameObject lockIcon; 
    public Button[] gameButtons; 
    
    public void LoadScene(int levelIndex)
    {
        
            string sceneName = "SampleScene" + levelIndex;
            SceneManager.LoadScene(sceneName);
    }
    void Awake() {
        for (int i = 1; i <= 9; i++)
        {
            gameButtons[i].interactable = false;
        }
        
    }
    private void Start()
    {
        int playerLevel = PlayerPrefs.GetInt("PlayerLevel");

        if (playerLevel >= 1)
        {
            for (int i = 1; i <= playerLevel; i++)
            {
                gameButtons[i].interactable = true;
            }
        }
        Cursor.visible = true;
    }

    private void UpdateButtonInteractivity()
    {
       
    }
    private void OnApplicationQuit()
    {
        // Очистите PlayerPrefs при закрытии игры
        PlayerPrefs.DeleteAll();
    }
    
}