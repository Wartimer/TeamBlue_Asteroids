using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TeamBlue_Asteroids
{
    internal class BuffFactory : IBuffFactory
    {
        
        private readonly BuffData _data;

        internal BuffFactory(BuffData data)
        {
            _data = data;
        }

        public GameObject CreateBuffElement(BuffType type)
        {
            return _data.CreateBuffElement(type);
        }
    }
}
