using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenechanger : MonoBehaviour
{
    public GameObject lockIcon; // Ссылка на объект иконки замка
    public Button[] gameButtons; // Количество разблокированных уровней, начиная с первого

    public void LoadScene(int levelIndex)
    {
        
            string sceneName = "SampleScene" + levelIndex;
            SceneManager.LoadScene(sceneName);
    }

    void Start()
    {
        

        
    }

    private void UpdateButtonInteractivity()
    {
       
    }

    
}