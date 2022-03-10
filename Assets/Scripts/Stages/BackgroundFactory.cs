using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class BackgroundFactory : IBackGroundFactory
    {
        private readonly BackgroundData _data;

        internal BackgroundFactory(Data data)
        {
            _data = data.BgData;
        }
        
        public BackgroundView CreateBackground(BgType type)
        {
            return Object.Instantiate(_data.GetBackground(type));
        }
    }
}