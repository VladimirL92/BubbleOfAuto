using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Score;

    public TMP_Text ScoreText;



    public void AddScore( int points)
    {
        Score += points;
        ScoreText.text = Score.ToString();
    }
}
