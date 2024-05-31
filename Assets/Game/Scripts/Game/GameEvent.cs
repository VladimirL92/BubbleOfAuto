using System.Collections.Generic;
using UnityEngine;


public class GameEvent : MonoBehaviour
{
    private List<GameObject> EventFolowers = new List<GameObject>();
    private void Start()
    {
        FindObjectsWithInterface();
    }


    public void Pause()
    {
        foreach(var obj in EventFolowers)
        {
            obj.GetComponent<IGameEvent>().Pause();
        }
    }
    public void Play()
    {
        foreach (var obj in EventFolowers)
        {
            obj.GetComponent<IGameEvent>().Play();
        }
    }

    public void GameOver()
    {
        foreach (var obj in EventFolowers)
        {
            obj.GetComponent<IGameEvent>().GameOver();
        }
    }

    public void Win()
    {
        foreach (var obj in EventFolowers)
        {
            obj.GetComponent<IGameEvent>().Win();
        }
    }
    private void FindObjectsWithInterface()
    {
        EventFolowers.Clear();
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (var obj in allObjects)
        {
            if (obj.GetComponent("IGameEvent") != null)
            {
                EventFolowers.Add(obj);
            }
        }
    }
}
