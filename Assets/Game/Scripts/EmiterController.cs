using UnityEngine;

public class EmiterController : MonoBehaviour,IGameEvent 
{
    [HideInInspector]
    public GameObject Entity;
    public EntityContainer Container;
    public Transform Anchor;
    [HideInInspector]
    public bool Pause;
    public float DelaySpawn;
    private float timer;
    private bool SpawnNew;
    private bool Press;

    public Rect SpaceMouse;
    private void Start()
    {
        Press = false;
        timer = DelaySpawn + 1;
        Pause = false;
        Entity = Container.EntityCreate();
        SpawnNew = false;
    }

    void Update()
    {
        if (!Pause)
        {
            Press = Input.GetKeyUp(KeyCode.Mouse0);
            moveEmiter();
            SpawnEntity();
            timer += Time.deltaTime;
        }
    }
    private void SpawnEntity()
    {
        if (SpawnNew & timer > DelaySpawn)
        {
            Entity = Container.EntityCreate();
            SpawnNew = false;
        }
        if (!SpawnNew)
        {
            Entity.transform.position = Anchor.position;
            if (Press)
            {
                var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (mousePos.x <= SpaceMouse.xMax &
                    mousePos.x >= SpaceMouse.xMin &
                    mousePos.y <= SpaceMouse.xMax)
                {
                    Press = false;
                    Container.AddPhysics(Entity);
                    timer = 0;
                    SpawnNew = true;
                }

            }
        }
    }
    private void moveEmiter()
    {
        var dif = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dif.x = Mathf.Clamp(dif.x, SpaceMouse.xMin,SpaceMouse.xMax);
        transform.position = new Vector2(dif.x, transform.position.y);
    }
    
        private void OnDrawGizmos()
        {
            var upLeft = new Vector2(SpaceMouse.xMin, SpaceMouse.yMin);
            var upRight = new Vector2(SpaceMouse.xMax, SpaceMouse.yMin);
            var downLeft = new Vector2(SpaceMouse.xMin, SpaceMouse.yMax);
            var downRight = new Vector2(SpaceMouse.xMax, SpaceMouse.yMax);
            Gizmos.DrawLine(upLeft, upRight);
            Gizmos.DrawLine(upLeft, downLeft);
            Gizmos.DrawLine(downLeft, downRight);
            Gizmos.DrawLine(downRight, upRight);

        }

    void IGameEvent.Pause()
    {
        throw new System.NotImplementedException();
    }

    public void Play()
    {
        throw new System.NotImplementedException();
    }

    public void Win()
    {
        throw new System.NotImplementedException();
    }

    public void GameOver()
    {
        throw new System.NotImplementedException();
    }
}
