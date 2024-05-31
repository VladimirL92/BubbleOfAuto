
using UnityEngine;

public class PanelMenuCloser : MonoBehaviour
{
    public Rect Area;
    private void Update()
    {
        var mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (mouse.x >= Area.xMin &
                mouse.x <= Area.xMax &
                mouse.y >= Area.yMin &
                mouse.y <= Area.yMax )
            {
                transform.gameObject.SetActive(false);
            }
        }
    }
    private void OnDrawGizmos()
    {
        var upLeft = new Vector2(Area.xMin, Area.yMin);
        var upRight = new Vector2(Area.xMax, Area.yMin);
        var downLeft = new Vector2(Area.xMin, Area.yMax);
        var downRight = new Vector2(Area.xMax, Area.yMax);
        Gizmos.DrawLine(upLeft, upRight);
        Gizmos.DrawLine(upLeft, downLeft);
        Gizmos.DrawLine(downLeft, downRight);
        Gizmos.DrawLine(downRight, upRight);
    }
}
