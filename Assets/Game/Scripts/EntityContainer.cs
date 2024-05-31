using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EntityContainer : MonoBehaviour,IGameEvent
{
    [Header("Entities Setting")]
    public float SizeSteep;
    public float StartSize;
    public float SpeedScaler;
    public int maxSpawnRangeEntity = 1;
    public List<Sprite> Entities;
    [Header("Game Manager")]
    public GameEvent GameEvent;
    public ScoreManager ScoreCounter;
    public float DelayWin;
    [Header("Entity_Z")]
    public float Z;

    private bool win;
    private float timerWin;

    private void Start()
    {
        win = false;
    }
    private void Update()
    {
        if (win)
        {
            if (timerWin > DelayWin)
            {
                GameEvent.Win();
            }
            timerWin += Time.deltaTime;
        }
    }

    public  GameObject EntityCreate ()
    {
        var index = UnityEngine.Random.Range(1, maxSpawnRangeEntity) - 1;
        return EntityCreate(index);
    }

    public GameObject EntityCreate (int indexNew, Vector2 position)
    {
        var entity = EntityCreate(indexNew);
        entity.transform.position = new Vector3(position.x,position.y,Z);
        return entity;
    }
    public GameObject EntityCreate(int indexNew)
    {
        var index = 0;
        if (indexNew < Entities.Count - 1)
        {
            index = indexNew;
        }
        else
        {
            win = true;
            Debug.Log("Win!!");
            index = Entities.Count - 1;
        }
        Debug.Log(index);
        var obj = new GameObject();
        obj.tag = "Entity";
        obj.transform.parent = transform;
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, Z);
        obj.transform.AddComponent<SpriteRenderer>().sprite = Entities[index];
        obj.transform.GetComponent<SpriteRenderer>().drawMode = SpriteDrawMode.Sliced;

        var size = StartSize + (index * SizeSteep);


        obj.transform.GetComponent<SpriteRenderer>().size = new Vector2(size, size);
        obj.AddComponent<EntityController>();
        var entityController = obj.GetComponent<EntityController>();

        entityController.MyCount = index;
        entityController.MySize = size;
        entityController.SpeedScaler = SpeedScaler;
        entityController.Score = ScoreCounter;

        return obj;
    }



    public void AddPhysics (GameObject obj)
    {
        obj.AddComponent<CircleCollider2D>();
       var temp =  obj.AddComponent<Rigidbody2D>();

        temp.drag = 1;
    }

    public void Pause()
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
