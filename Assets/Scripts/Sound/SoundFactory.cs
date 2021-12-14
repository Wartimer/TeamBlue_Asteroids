
using UnityEngine;


namespace TeamBlue_Asteroids
{
    internal class SoundFactory : ISoundFactory
    {
        private readonly SoundsData _data;

        internal SoundFactory(SoundsData data)
        {
            _data = data;
        }

        public AudioClip GetSound(SoundsType type)
        {
            return _data.GetSound(type);
        }
    }
}
