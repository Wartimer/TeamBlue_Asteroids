using System;

namespace TeamBlue_Asteroids
{
    internal interface IRemoveFromControllers : IController
    {
        event Action<IController> PlayerRemoved;
    }
}