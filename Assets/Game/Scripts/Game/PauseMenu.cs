using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Dash")]
    public Transform DashGamePause;
    public Transform DashGameOver;
    public Transform DashGameWin;
    public EmiterController Emiter;

    [Header("Setting")]
    public float DelayWin;
    public float DelayDead;

    private float TimerWin;
    private float timerDead;
    private void Start()
    {
        Time.timeScale = 1;
        TimerWin = 0;
        timerDead = 0;
    }
    public void PauseOn()
    {
        Time.timeScale = 0;
        Emiter.Pause = true;
        DashGamePause.gameObject.SetActive(true);
    }
    public void PauseOff()
    {
        Time.timeScale = 1;
        Emiter.Pause = false;
        DashGamePause.gameObject.SetActive(false);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Emiter.Pause = true;
        DashGameOver.gameObject.SetActive(true);
        //Save.SaveMaxScore(1);
    }
    public void GameWin()
    {
        DashGameWin.gameObject.SetActive(true);
        Emiter.Pause = true;
        Time.timeScale = 0;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
