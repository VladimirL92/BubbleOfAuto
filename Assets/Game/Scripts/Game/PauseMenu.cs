using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour , IGameEvent
{
    public ScoreManager ScoreManager;
    [Header("Dash")]
    public Transform DashGamePause;
    public Transform DashGameOver;
    public Transform DashGameWin;
    public EmiterController Emiter;

    [Header("Setting")]
    public float DelayWin;
    public float DelayDead;

    [Header("GameTimeScale")]
    public float GameTimeScale = 1f;
    private void Start()
    {
        ScoreManager = GetComponent<ScoreManager>();
        Time.timeScale = GameTimeScale;
    }
    public void ResetGame()
    {
        var scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
    }
        public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        Emiter.Pause = true;
        DashGamePause.gameObject.SetActive(true);
    }
    public void Play()
    {
        Time.timeScale = GameTimeScale;
        Emiter.Pause = false;
        DashGamePause.gameObject.SetActive(false);
    }
    public void Win()
    {
        ScoreManager.SaveScore();
        DashGameWin.gameObject.SetActive(true);
        Emiter.Pause = true;
        Time.timeScale = 0;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        Emiter.Pause = true;
        DashGameOver.gameObject.SetActive(true);
    }
}
