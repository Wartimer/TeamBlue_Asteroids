using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    [CreateAssetMenu(fileName = "AsteroidData", menuName = "Data/AsteroidData", order = 51)]
    internal class EnemyData : ScriptableObject
    {
        [Serializable]
        private struct EnemyInfo
        {
            public EnemyType Type;
            public EnemyView EnemyPrefab;
        }

        [SerializeField] private List<EnemyInfo> _enemyInfos;

        public EnemyView GetEnemy(EnemyType type)
        {
            var enemyInfo = _enemyInfos.FirstOrDefault(info => info.Type == type);
            if (enemyInfo.EnemyPrefab == null)
            {
                throw new InvalidOperationException($"Enemy type {type} not found");
            }
            
            return enemyInfo.EnemyPrefab;
        }
    }
}