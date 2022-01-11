using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class BackgroundController : IExecute
    {
        private List<StageBackgroundView> _stageBackgroundViews;

        internal BackgroundController()
        {
            _stageBackgroundViews = Object.FindObjectsOfType<StageBackgroundView>().ToList();
        }
        
        public void Execute(float deltaTime)
        {
            foreach (var background in _stageBackgroundViews)
            {
                background.Execute(deltaTime);
            }
        }

        internal void AddBackground(StageBackgroundView bg)
        {
            _stageBackgroundViews.Add(bg);
        }
    }
}