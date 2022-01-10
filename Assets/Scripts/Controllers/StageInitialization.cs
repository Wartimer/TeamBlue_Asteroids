using UnityEditor.SceneManagement;
using UnityEngine;


namespace TeamBlue_Asteroids
{
    internal sealed class StageInitialization: IInitialization
    {
        private readonly StageFactory _stageFactory;
        private GameObject _stage;

        internal StageInitialization(StageFactory stageFactory)
        {
            _stageFactory = stageFactory;
            _stage = _stageFactory.CreateStage();
        }
        
        public void Initialization()
        {
            
        }
    }
}