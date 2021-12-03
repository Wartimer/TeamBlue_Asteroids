using System.Collections.Generic;

namespace TeamBlue_Asteroids
{
    internal class InteractiveObjectsController : ILateExecute
    {
        private List<EnemyView> _executeObjects;

        internal InteractiveObjectsController()
        {
            _executeObjects = new List<EnemyView>();
        }
        
        public void LateExecute(float time)
        {
            for (int i = 0; i < _executeObjects.Count; i++)
            {
                _executeObjects[i].Execute(time);
            }
        }

        internal void AddObject(EnemyView obj)
        {
            _executeObjects.Add(obj);
        }
    }
    
}