using System.Collections.Generic;

namespace TeamBlue_Asteroids
{
    internal class InteractiveObjectsController : IFixedExecute
    {
        private List<EnemyView> _executeObjects;
        private ExplosionSpawnController _explosionSpawnController;

        internal InteractiveObjectsController(ExplosionSpawnController explosionSpawnController)
        {
            _executeObjects = new List<EnemyView>();
            _explosionSpawnController = explosionSpawnController;
        }
        
        public void FixedExecute(float time)
        {
            for (int i = 0; i < _executeObjects.Count; i++)
            {
                _executeObjects[i].Execute(time);
            }
        }

        internal void AddObject(EnemyView obj)
        {
            obj.EnemyDead += RemoveObject;
            _executeObjects.Add(obj);
        }

        private void RemoveObject(EnemyView obj)
        {
            _explosionSpawnController.SpawnExplosion(obj.transform.position);   
            obj.EnemyDead -= RemoveObject;
            _executeObjects.Remove(obj);
        }
    }
    
}