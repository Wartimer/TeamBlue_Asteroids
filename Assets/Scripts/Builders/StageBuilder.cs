
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class StageBuilder
    {
        private readonly Data _data;
        private readonly StageFactory _stageFactory;
        private readonly BackgroundFactory _backgroundFactory;
        private readonly StarsFactory _starsFactory;

        internal StageBuilder(Data data)
        {
            _data = data;
            _backgroundFactory = new BackgroundFactory(_data);
            _stageFactory = new StageFactory(_data);
            _starsFactory = new StarsFactory(_data);
        }

        internal GameObject CreateBackGround(BgType type)
        {
            return _backgroundFactory.CreateBackground(type);
        }

        internal void CreateStars()
        {
            _starsFactory.CreateStars();
        }
        
        internal void CreateStage()
        {
            _stageFactory.CreateStage();
        }

        
    }
}