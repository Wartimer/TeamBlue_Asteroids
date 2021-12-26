using System;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    public interface IUserKeyInputProxy
    {
        event Action<KeyCode> KeyPressed;
    }
}