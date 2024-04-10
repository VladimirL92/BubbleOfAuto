using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EntityContainer : MonoBehaviour
{
    [Header("Entities Setting")]
    public float SizeMultiplier = 0.2f;
    public float SpeedScaler;
    public int maxSpawnRangeEntity = 1;
    public List<Sprite> Entities;
    [Header("Game Manager")]
    public PauseMenu GameManager;
    
    public  GameObject EntityCreate ()
    {
        var index = UnityEngine.Random.Range(1, maxSpawnRangeEntity) - 1;
        return EntityCreate(index);
    }

    public GameObject EntityCreate (int indexNew, Vector2 position)
    {
        var entity = EntityCreate(indexNew);
        entity.transform.position = position;
        return entity;
    }

    public GameObject EntityCreate(int indexNew)
    {
        var index = 0;
        if (indexNew < Entities.Count)
        {
            index = indexNew;
        }
        else
        {
            index = Entities.Count - 1;
            GameManager.GameWin();
        }
        var obj = new GameObject();
        obj.tag = "Entity";
        obj.transform.parent = transform;
        obj.transform.position = transform.position;
        obj.transform.AddComponent<SpriteRenderer>().sprite = Entities[index];
        obj.transform.GetComponent<SpriteRenderer>().drawMode = SpriteDrawMode.Sliced;
        var size = SizeMultiplier * (index + 1);
        obj.transform.GetComponent<SpriteRenderer>().size = new Vector2(size, size);
        obj.AddComponent<EntityController>();
        var entityController = obj.GetComponent<EntityController>();

        entityController.MyCount = index;
        entityController.MySize = size;
        entityController.SpeedScaler = SpeedScaler;

        return obj;
    }



    public void AddPhysics (GameObject obj)
    {
        obj.AddComponent<CircleCollider2D>();
        obj.AddComponent<Rigidbody2D>();
    }
}
