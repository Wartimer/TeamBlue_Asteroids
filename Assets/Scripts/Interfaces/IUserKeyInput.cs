using System;

namespace TeamBlue_Asteroids
{
    public interface IUserKeyInput
    {
        event Action<string> KeyPressed;
        string GetKey();
    }
}