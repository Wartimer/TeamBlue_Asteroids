using UnityEngine;

namespace TeamBlue_Asteroids
{
    public class BackGroundInitialization : IInitialization
    {
        private readonly BackgroundFactory _backgroundFactory;
        private GameObject _background;

        internal BackGroundInitialization(BackgroundFactory backgroundFactory)
        {
            _backgroundFactory = backgroundFactory;
            _background = backgroundFactory.CreateBackground(BgType.FastBg);
            _background = backgroundFactory.CreateBackground(BgType.SlowBG);
        }
        
        public void Initialization()
        {
            
        }

        internal GameObject GetBackground()
        {
            return _background;
        }
    }
}