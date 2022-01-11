using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDisplay : MonoBehaviour
{
    private bool isFullScreen;

    public void FullScreenToogle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

}
