using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class ResolutionChecker
    {
        private int _width;
        private int _height;
        
        internal ResolutionChecker()
        {
            _width = Screen.currentResolution.width;
            _height = Screen.currentResolution.height;
        }

        internal (int, int) GetCurrentResolution()
        {
            return (_width, _height);
        }
    }
}