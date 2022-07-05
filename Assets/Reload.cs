using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Threading;

public class Reload : MonoBehaviour
{

    public UnityEvent OnWalls;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            OnWalls.Invoke();
            Thread.Sleep(200);
            ScoreCountSave.SaveBestScore();
            ScoreCountSave.ScoreInt = 0;
            SceneManager.LoadScene(1);
        }
    }
}
