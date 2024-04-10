using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverEvent : MonoBehaviour
    
{
    private bool collisionEnter;
    public float timer;

    public float TimeDetectDead;

    public PauseMenu menu;

    public Vector2 PointA;
    public Vector2 PointB;

    private void Start()
    {
        collisionEnter = false;
        timer = 0;
    }

    private void Update()
    {
        if (Physics2D.OverlapArea(PointA, PointB) != null)
        {
            Debug.Log("trigger");
            timer += Time.deltaTime;
            if (timer > TimeDetectDead)
            {
                DeadAction();
            }
        }
        else
        {
            timer = 0;
        }
    }

    private void DeadAction()
    {
        menu.GameOver();
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(PointA, PointB);
    }
}
