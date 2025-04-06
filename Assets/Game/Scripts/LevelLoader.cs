using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static int Lev;
    public Vector2 PointToInstantiate;
    public int LoadLevelNum;
    [Space]
    public Transform[] LevelList;

    private void Start()
    {
        LoadLevelNum = Lev;
        LoadLevel(LoadLevelNum);
    }

    public void LoadLevel(int LevelNum)
    {
        var num = LevelNum - 1;
        if (num > LevelList.Length)
        {
            num = LevelList.Length;
        }
        else if (num < 0 )
        {
            num = 0;
        }
        var _CurrentLevel = Instantiate(LevelList[num],transform);
        _CurrentLevel.position = PointToInstantiate;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointToInstantiate, 0.3f);
    }

    [CustomEditor(typeof(LevelLoader))]
    public class MyScriptEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            LevelLoader myScript = (LevelLoader)target;
            if (GUILayout.Button("LoadPrefab"))
            {
                myScript.LoadLevel(myScript.LoadLevelNum);
            }
            DrawDefaultInspector();
        }
    }



    public Level level1;

    private void Update()
    {
        var image = level1.Background;
    }
}
