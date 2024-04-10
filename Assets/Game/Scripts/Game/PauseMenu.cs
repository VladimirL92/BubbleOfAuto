using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Canvas PauseCanvas;

    public Canvas GameOverCanvas;

    public Canvas GameWinCanvas;

    public EmiterController Emiter;

    public void PauseOn()
    {
        Time.timeScale = 0;
        Emiter.Pause = true;
        PauseCanvas.gameObject.SetActive(true);
    }
    public void PauseOff()
    {
        Time.timeScale = 1;
        Emiter.Pause = false;
        PauseCanvas.gameObject.SetActive(false);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Emiter.Pause = false;
    }

    public void GameOver()
    {
        GameOverCanvas.gameObject.SetActive(true);
        Emiter.Pause = true;
        Time.timeScale = 0;
    }
    public void GameWin()
    {
        GameWinCanvas.gameObject.SetActive(true);
        Emiter.Pause = true;
        Time.timeScale = 0;
    }

}
