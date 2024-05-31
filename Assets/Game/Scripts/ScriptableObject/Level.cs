using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "New Level", order = 51)]
public class Level : ScriptableObject
{
    public string LevelName;
    public GameObject Arena;
    public Sprite Background;

}
