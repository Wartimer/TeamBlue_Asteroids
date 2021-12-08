using System;
using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace TeamBlue_Asteroids
{
  
    internal class PlayerShootController : IExecute
    {
        private Shooter _shooter;
        private EnemyScanner _enemyScanner;
        
        internal PlayerShootController(Shooter shooter, EnemyScanner enemyScanner)
        {
            _shooter = shooter;
            _enemyScanner = enemyScanner;
        }
        
        public void Execute(float time)
        {
            _shooter.Shoot(time);
            _enemyScanner.ScanTargets(time);

        }


        


       

    }
}
