using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LevelScaler : MonoBehaviour
{
    public string buttonText = "SizeAlign";

    [CustomEditor(typeof(LevelScaler))]
    public class MyScriptEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            LevelScaler myScript = (LevelScaler)target;

            // Отображаем кнопку
            if (GUILayout.Button(myScript.buttonText))
            {
                // Действие при нажатии на кнопку
                myScript.ResizeCamera();
                // Тут можете добавить любое действие, которое нужно выполнить
            }

            // Рисуем остальные элементы инспектора
            DrawDefaultInspector();
        }
    } 

    public float StartSizeCamera = 12f;
    public float StepResizeCamera = 0.1f;
    public float DefaultSizeCamera = 6f;
    public Transform AnchorWidthCameraAlign;

    public float LeftAnchor;
    private void ResizeCamera()
    {
        var leftBorder = CenterAlign.x - Width / 2;
        var downBorder = CenterAlign.y - Height / 2;

        Camera.main.orthographicSize = StartSizeCamera;
        while (ScreenLDPoint().x < leftBorder && ScreenLDPoint().y < downBorder)
        {
            Camera.main.orthographicSize -= StepResizeCamera;
        }
    }

    [Space]
    [Header("AlignCamera")]
    public float Width;
    public float Height;
    public Vector2 CenterAlign;
    void OnDrawGizmos()
    {
        var center = CenterAlign;
        var width2 = Width / 2;
        var height2 = Height / 2;
        var points = new Vector3[4]
            {
                 new Vector2(center.x - width2, center.y - height2),
                 new Vector2(center.x + width2, center.y - height2),
                 new Vector2(center.x + width2, center.y + height2),
                 new Vector2(center.x - width2, center.y + height2)
            };

        Gizmos.DrawLineStrip(points, true);
    }
    private Vector3 ScreenLDPoint()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    }
}
