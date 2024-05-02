using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelScript : MonoBehaviour
{
    public PauseMenu GameState;
    private void OnMouseDown()
    {
        GameState.PauseOff();
    }
}
