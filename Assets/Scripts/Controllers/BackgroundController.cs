using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class BackgroundController : ILateExecute
    {
        private StageBackgroundView _stageBackgroundView;

        internal BackgroundController()
        {
            _stageBackgroundView = Object.FindObjectOfType<StageBackgroundView>();
        }
        public void LateExecute(float deltaTime)
        {
            _stageBackgroundView.Execute(deltaTime);
        }
    }
}