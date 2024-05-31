using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEvent
{
    public void Pause();

    public void Play();

    public void Win();

    public void GameOver();
}
