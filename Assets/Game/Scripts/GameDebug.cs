using UnityEngine;

public class GameDebug : MonoBehaviour
{
    public EntityContainer Container;

    public PauseMenu PauseMenu;

    public EmiterController Emiter;


    public void DebugWin()
    {
        var ent = Container.EntityCreate(Container.Entities.Count + 1);
        Container.AddPhysics(ent);
        ent.transform.position = Emiter.Anchor.position;

    }
}
