using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenToggleView : MonoBehaviour
{
    private bool isFullScreen;

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

}
