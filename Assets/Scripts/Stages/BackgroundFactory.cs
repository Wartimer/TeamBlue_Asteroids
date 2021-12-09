using System;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class BackgroundFactory : IBackGroundFactory
    {
        private readonly Data _data;

        internal BackgroundFactory(Data data)
        {
            _data = data;
        }
        
        public GameObject CreateBackground(BgType type)
        {
            if(type == BgType.FastBg)
                return _data.BackGround01;
            if(type == BgType.SlowBG)
                return _data.BackGround02;
            
            return null;
        }
    }
}