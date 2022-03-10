using UnityEngine;


namespace TeamBlue_Asteroids {
    internal interface IBuffFactory
    {
        GameObject CreateBuffElement(BuffType type);
    }
}
