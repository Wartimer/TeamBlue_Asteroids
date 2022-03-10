using UnityEngine.UI;
using UnityEngine;



namespace TeamBlue_Asteroids
{
    internal class GameInterfaceView : UIView
    {
        private ScoreText _scoreText;
        internal ScoreText ScoreText => _scoreText;

       
        internal GameInterfaceView(GameObject element) : base(element)
        {
            _scoreText = element.GetComponentInChildren<ScoreText>();
            
        }
    }
}
