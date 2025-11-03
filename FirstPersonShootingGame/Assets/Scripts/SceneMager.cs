using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMager : MonoBehaviour
{
    public string PlayScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartScene()
    {
        SceneManager.LoadScene(PlayScene);
        //AudioManager.instance.PlaySFX(0);
    }

    public void QuitMode()
    {
        Application.Quit();
    }
}
