using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class StageFactory : IStageFactory
    {
        private readonly Data _data;

        internal StageFactory(Data data)
        {
            _data = data;
        }
        
        public GameObject CreateStage()
        {
            var obj = _data.Stage01;
            return obj;
        }
    }
}