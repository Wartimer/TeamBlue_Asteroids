using System;
using UnityEngine;
using UnityEngine.Events;

namespace TeamBlue_Asteroids
{
    public class GlobalEventManager
    {
        public static UnityEvent OnEnemyKillded = new UnityEvent();

        public static void SendEnemyKilled()
        {
            OnEnemyKillded?.Invoke();
        }
    }
}
