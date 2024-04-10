using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    public int MyCount;
    public float MySize;
    public float SpeedScaler;
    public EntityContainer container;

    public float Speed;
    private SpriteRenderer myRenderer;
    private float sizeTemp;
    private bool imColision = false;

    enum MyState
    {
        Start,
        Work,
        Destroed,
        Replacement
    }
    private MyState mystate;

    private void Start()
    {
        container = transform.parent.GetComponent<EntityContainer>();
        mystate = MyState.Start;
        myRenderer = GetComponent<SpriteRenderer>();
        sizeTemp = 0;
        SizeSet(0.01f);

    }
    private void Update()
    {
        if (mystate == MyState.Start)
        {
            ImStarted();
        }
        if (mystate == MyState.Destroed)
        {
            ImDestroy();
        }
        if (mystate == MyState.Replacement)
        {
            ImReplace();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Entity")
        {
           if (collision.gameObject.GetComponent<EntityController>().MyCount == MyCount)
            {
                if ( transform.GetComponent<Rigidbody2D>().velocity.magnitude > collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude)
                {
                    mystate = MyState.Replacement;
                }
                else
                {
                    mystate = MyState.Destroed;
                }
                imColision = true;
            }
        }
    }

    private void ImStarted()
    {
        if (transform.localScale.magnitude < 1)
        {
            sizeTemp += Time.deltaTime * SpeedScaler;
            SizeSet(sizeTemp);
        }
        else
        {
            sizeTemp = 1;
            SizeDefault();
            mystate = MyState.Work;
        }
    }
    private void ImDestroy()
    {
        if (sizeTemp > 0)
        {
            sizeTemp -= Time.deltaTime * SpeedScaler;
            SizeSet(sizeTemp);
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }
    private void ImReplace()
    {

        var ent = container.EntityCreate(MyCount + 1, transform.position);
        container.AddPhysics(ent);
        mystate = MyState.Destroed;
    }

    private void SizeSet( float size)
    {
        transform.localScale = new Vector2(size, size);
    }

    private void SizeDefault()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
