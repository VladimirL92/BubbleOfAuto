using UnityEngine;

public class GameOverEvent : MonoBehaviour
    
{
    public float timer;
    public float TimeDetectDead;
    public GameEvent GameEvent;
    public float WidhtLineCast;

    private void Start()
    {
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
        GameEvent.GameOver();
    }

    private void OnDrawGizmos()
    {
        var a = new Vector2(transform.position.x - (WidhtLineCast / 2),transform.position.y);
        var b = new Vector2(transform.position.x + (WidhtLineCast / 2),transform.position.y);
        Gizmos.DrawLine(a, b);
    }
}
