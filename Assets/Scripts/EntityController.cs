using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    public EntityManager Manager;
    public int MyCount;
    public int MyPriority;

    private void Start()
    {
        Manager = transform.parent.GetComponent<EntityManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.parent == transform.parent)
        {
            var count = collision.transform.GetComponent<EntityController>().MyCount;
            var entity = collision.transform;
            if (MyCount == count && MyPriority > collision.transform.GetComponent<EntityController>().MyPriority)
            {
                Debug.Log("collision pare");
                Manager.CollisionAdd(transform, collision.transform);
            }
        }

    }


}
