using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmiterController : MonoBehaviour
{
    [HideInInspector]
    public GameObject Entity;

    public EntityContainer Container;

    public Transform Anchor;

    public Vector2 MouseClamp;
    [HideInInspector]
    public bool Pause;

    private void Start()
    {
        Pause = false;
        Entity = Container.EntityCreate();
    }
    void Update()
    {
        if (!Pause)
        {
            NonPausePlay();
        }

    }
    

    private void NonPausePlay()
    {
        var dif = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dif.x = Mathf.Clamp(dif.x, MouseClamp.x, MouseClamp.y);
        transform.position = new Vector2(dif.x, transform.position.y);

        Entity.transform.position = Anchor.position;

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            EntityStart();
        }
    }

    public void EntityStart()
    {
        Container.AddPhysics(Entity);
        Entity = Container.EntityCreate();
    }
}
