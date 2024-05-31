using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    [Header("Link")]
    public TMP_Text ScoreText;
    public TMP_Text MaxScore;

    private string tempLevel;

    private void Start()
    {
        tempLevel = SceneManager.GetActiveScene().buildIndex.ToString();
        LoadScore();
    }
    public void ClearScore()
    {
        PlayerPrefs.DeleteAll();
    }
    public void SaveScore()
    {
        PlayerPrefs.SetInt("MaxScore" + tempLevel, Score);
        PlayerPrefs.Save();

        var max = PlayerPrefs.GetInt("MaxScore" + tempLevel);
        MaxScore.text = "MaxScore" + max.ToString();
    }
    public void LoadScore()
    {
        var max = PlayerPrefs.GetInt("MaxScore" + tempLevel);
        MaxScore.text = "MaxScore" + max.ToString();
    }
    public void AddScore(int points)
    {
        Score += points;
        ScoreText.text = Score.ToString();
    }
}
