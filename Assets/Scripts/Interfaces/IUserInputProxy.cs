using System;

namespace TeamBlue_Asteroids
{
    public interface IUserInputProxy
    {
        event Action<float> AxisChange;
        void GetAxis();
    }
}