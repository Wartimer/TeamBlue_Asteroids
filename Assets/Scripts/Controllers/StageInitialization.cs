using UnityEditor.SceneManagement;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class StageInitialization: IInitialization
    {
        private StageBuilder _stageBuilder;
        private readonly Data _data;
        private BackgroundController _backgroundController;
        private Controllers _controllers;

        internal BackgroundController BackgroundController => _backgroundController;
        
        internal StageInitialization(Data data)
        {
            _data = data;
            _stageBuilder = new StageBuilder(_data);
            _stageBuilder.CreateStars();
            _stageBuilder.CreateStage();
            _stageBuilder.CreateBackGround(BgType.SlowBG);
            _stageBuilder.CreateBackGround(BgType.FastBg);
            _backgroundController = new BackgroundController();
        }
        
        public void Initialization()
        {
        }
    }
}