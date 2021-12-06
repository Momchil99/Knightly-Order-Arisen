using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public int nextScene;

    private void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex +1;
        if (nextScene >= SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }
    }

    public void GetCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void SwitchScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
