using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TeamBlue_Asteroids
{
    internal sealed class BackgroundController : IExecute, IDisposable
    {
        private List<BackgroundView> _stageBackgroundViews;
        private readonly BackgroundData _bgData;

        internal BackgroundController(BackgroundData bgData)
        {
            _bgData = bgData;
            _stageBackgroundViews = Object.FindObjectsOfType<BackgroundView>().ToList();
            foreach (var bg in _stageBackgroundViews)
            {
                 bg.Init(_bgData.GetBgConfig(bg.Type));
            }
        }
        
        public void Execute(float deltaTime)
        {
            foreach (var background in _stageBackgroundViews)
            {
                var direction = Vector3.down;
                var position = direction * background.Speed * deltaTime;
                background.Move(position);
            }
        }

        public void Dispose()
        {
            _stageBackgroundViews.Clear();
        }
    }
}