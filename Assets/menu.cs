using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void OnPlayHandler()
    {
        Pause.GameIsPause = false;
        SceneManager.LoadScene(1);
    }
    public void OnExitHandler()
    {
        Application.Quit();
    }
}
