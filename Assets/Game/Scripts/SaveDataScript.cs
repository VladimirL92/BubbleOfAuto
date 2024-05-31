using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataScript : MonoBehaviour
{
    public void SaveMaxScore(int score)
    {
   
    }
    public int LoadMaxScore()
    {
        return PlayerPrefs.GetInt("MaxScore");
    }
}
