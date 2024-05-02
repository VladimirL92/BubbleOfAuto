using UnityEngine;

public class GameOverEvent : MonoBehaviour
    
{
    private bool collisionEnter;
    public float timer;

    public float TimeDetectDead;

    public PauseMenu menu;
    public float WidhtLineCast;

    private void Start()
    {
        collisionEnter = false;
        timer = 0;
    }

    private void Update()
    {
        var a = new Vector2(transform.position.x - (WidhtLineCast / 2), transform.position.y);
        var b = new Vector2(transform.position.x + (WidhtLineCast / 2), transform.position.y);

        if (Physics2D.Linecast(a,b))
        {
            Debug.Log("deadColision");
            timer += Time.deltaTime;
            if (timer > TimeDetectDead)
            {
                DeadAction();
                Debug.Log("dead");
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
        var a = new Vector2(transform.position.x - (WidhtLineCast / 2),transform.position.y);
        var b = new Vector2(transform.position.x + (WidhtLineCast / 2),transform.position.y);
        Gizmos.DrawLine(a, b);
    }
}
