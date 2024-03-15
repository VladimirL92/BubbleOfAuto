using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EntityManager : MonoBehaviour
{
    public  List<Transform> Entities;
    private List<(Transform,Transform)>  collisions= new List<(Transform,Transform)>();
    private int nextIndex;
    private int counterPriority = 0;
    private void Start()
    {
        nextIndex = Random.Range(0, Entities.Count);
    }

    public void CollisionAdd(Transform main, Transform slave)
    {
        collisions.Add((main, slave));
    }

    private void Update()
    {
        foreach (var temp in collisions)
        {
            var newPosition = temp.Item2.position;
            var newIndex = temp.Item1.transform.GetComponent<EntityController>().MyCount + 1;
            Destroy(temp.Item1.gameObject);
            Destroy(temp.Item2.gameObject);
            EntityInstantiate(newIndex, newPosition);

        }
        collisions.Clear();
    }

    public void EntityInstantiate(Vector3 position)
    {
        if (Entities.Count > 0)
        {
            createEntity(nextIndex, position);
            nextIndex = Random.Range(0, Entities.Count);
        }
        else
        {
            Debug.Log("Non element in array entities");
        }
    }

    public void EntityInstantiate(int index, Vector3 position)
    {
        if (index < Entities.Count)
        {
            createEntity(index, position);
        }
        else
        {
            createEntity(Entities.Count - 1, position);
        }
    }


    private void createEntity(int index,Vector3 position)
    {
        var tempEntity =  Instantiate(Entities[index],transform);
        tempEntity.transform.position = position;
        tempEntity.GetComponent<EntityController>().MyCount = index;
        tempEntity.GetComponent<EntityController>().MyPriority = counterPriority;
        tempEntity.GetComponent<EntityController>().Manager = transform.GetComponent<EntityManager>();
        counterPriority++;
    }

    
}
