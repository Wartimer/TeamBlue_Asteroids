using UnityEngine;

namespace TeamBlue_Asteroids
{
    public class BackGroundInitialization : IInitialization
    {
        private readonly BackgroundFactory _backgroundFactory;
        private GameObject _backgroundFast;
        private GameObject _backgroundSlow;

        internal BackGroundInitialization(BackgroundFactory backgroundFactory)
        {
            _backgroundFactory = backgroundFactory;
            _backgroundFast = backgroundFactory.CreateBackground(BgType.FastBg);
            _backgroundSlow = backgroundFactory.CreateBackground(BgType.SlowBG);
        }
        
        public void Initialization()
        {
            
        }

        internal GameObject GetBackgroundFast()
        {
            return _backgroundFast;
        }

        internal GameObject GetBackGroundSlow()
        {
            return _backgroundSlow;
        }
    }
}