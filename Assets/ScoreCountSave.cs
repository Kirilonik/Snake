
using UnityEngine;
using UnityEngine.UI;

public class ScoreCountSave : MonoBehaviour
{
    public Text BestScoreTxt;
    public static int BestScoreInt;
    public Text ScoreTxt;
    public static int ScoreInt = 0;

    void Start()
    {

        if (PlayerPrefs.HasKey("BestScore")) {
            BestScoreInt = PlayerPrefs.GetInt("BestScore");
            BestScoreTxt.text = BestScoreInt.ToString();
        }
    }
    private void Update()
    {
        ScoreTxt.text = ScoreInt.ToString();
    }
    public static void ShowBestScore()
    {
        if (BestScoreInt < ScoreInt)
            BestScoreInt = ScoreInt;
    }
    public static void SaveBestScore()
    {
        if (PlayerPrefs.GetInt("BestScore") < BestScoreInt)
            PlayerPrefs.SetInt("BestScore", BestScoreInt);
    }
}
