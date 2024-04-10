using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public TMP_Text Text;

    private int fpsCounter;
    private float timer;
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
            Text.text = fpsCounter.ToString();
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
