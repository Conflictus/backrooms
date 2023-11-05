using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenechanger : MonoBehaviour
{
    public GameObject lockIcon; // Ссылка на объект иконки замка
    public int currentProgress = 0;
    public Button[] gameButtons;
    public void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadScene2()
    {
            SceneManager.LoadScene("samplescene2");
    
    }

    public void LoadScene3()
    {
      
            SceneManager.LoadScene("SampleScene3 1");
        
    }

    public void LoadScene4()
    {
        
            SceneManager.LoadScene("SampleScene4");
        
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        UpdateGameButtonAvailability();
    }
    public void UpdateGameButtonAvailability()
{
    for (int i = 0; i < gameButtons.Length; i++)
    {
        gameButtons[i].interactable = (i <= currentProgress);
    }
}
    // Update is called once per frame
    void Update()
    {

    }
}