using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scenechanger : MonoBehaviour
{
    public void LoadScene() {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadScene2() {
        SceneManager.LoadScene("samplescene2");
    }
    public void LoadScene3() {
        SceneManager.LoadScene("SampleScene3 1");
    }
    public void LoadScene4() {
        SceneManager.LoadScene("SampleScene4");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
