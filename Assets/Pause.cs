using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuUi;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameIsPause) { 
                ResumeGame();
            }
            else { 
                PauseGame();
            }
            
        }
    }

    public void ResumeGame()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void PauseGame()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f; // остановка времени в игре, перестает работать все
        GameIsPause = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        GameIsPause = false;
        ScoreCountSave.SaveBestScore();
        ScoreCountSave.ScoreInt = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
        ScoreCountSave.SaveBestScore();
    }
}