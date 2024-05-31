using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuIdDevice : MonoBehaviour
{
    public TMP_Text TextMesh;

    private void Start()
    {
        TextMesh.text = "Id " + SystemInfo.deviceUniqueIdentifier;
    }
}
