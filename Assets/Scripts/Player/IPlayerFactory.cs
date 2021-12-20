using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal interface IPlayerFactory
    {
        GameObject CreatePlayer(PlayerType type);
    }
}