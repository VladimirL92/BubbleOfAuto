using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public TMP_Text Text;

    private int fpsCounter;
    private float timer;

    private int fPS;
    private void Start()
    {
        Application.targetFrameRate = 60;
        fpsCounter = 0;
        timer = 0;
    }
    void Update()
    {
        if (timer > 1)
        {
            fPS = fpsCounter;
            fpsCounter = 0;
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
            fpsCounter ++;
        }
    }
}
