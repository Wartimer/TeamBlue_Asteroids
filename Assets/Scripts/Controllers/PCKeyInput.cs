using System;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class PCKeyInput : IUserKeyInput
    {
       public string GetKey()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                return KeyManager.PAUSE;
            }
            if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
            {
                return KeyManager.FIRE;
            }
            return null;
        }
    }
}