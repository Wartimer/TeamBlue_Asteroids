using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class SpawnController: IExecute
    {
        private EnemyFactory _enemyFactory;
        private float _timeToNextSpawn = 1.5f;
        private float _firstSpawnTime = 0;
        private List<SpawnPoint> _spawnPoints;
        private InteractiveObjectsController _executeObjectsController;
        internal SpawnController(InteractiveObjectsController executeObjectsController)
        {
            _spawnPoints = Object.FindObjectsOfType<SpawnPoint>().ToList();
            _executeObjectsController = executeObjectsController;
        }
        
        public void Execute(float time)
        {
            _firstSpawnTime += time;
            if (_firstSpawnTime > _timeToNextSpawn)
            {
                GetEnemy(time);
                _firstSpawnTime = 0;
            }
        }

        private void GetEnemy(float time)
        {
            var pointIndex = Random.Range(0, _spawnPoints.Count+1);
            var rnd = Random.Range(0, 4);
            EnemyView enemy;
            switch (rnd)
            {
                case 0:
                    enemy = _enemyFactory.CreateEnemy(EnemyType.SmallAsteroid);
                    SpawnEnemy(enemy, _spawnPoints[pointIndex].transform.position);
                    break;
                case 1:
                    enemy = _enemyFactory.CreateEnemy(EnemyType.MediumAsteroid);
                    SpawnEnemy(enemy, _spawnPoints[pointIndex].transform.position);
                    break;
                case 2:
                    enemy = _enemyFactory.CreateEnemy(EnemyType.LargeAsteroid);
                    SpawnEnemy(enemy, _spawnPoints[pointIndex].transform.position);
                    break;

                case 3:
                    enemy = _enemyFactory.CreateEnemy(EnemyType.Ship);
                    SpawnEnemy(enemy, _spawnPoints[pointIndex].transform.position);
                    break;
            };
        }

        private void SpawnEnemy(EnemyView enemy, Vector3 position)
        {
            var obj = Object.Instantiate(enemy, position, Quaternion.identity);
            _executeObjectsController.AddObject(obj);
        }
    }
}