using UnityEngine;

namespace TeamBlue_Asteroids
{

    internal class BackgroundView : MonoBehaviour, IMove
    {
        [SerializeField] internal BgType _bgType;
        private float _speed;
        private Vector3 startPos;
        private float repeatWidth;
        internal float Speed => _speed;
        internal BgType Type => _bgType;

        private void Start()
        {
            startPos = transform.position; // Establish the default starting position 
            repeatWidth = GetComponent<BoxCollider2D>().size.y/2; // Set repeat width to half of the background
        }
        
        public void Move(Vector3 position)
        {
            transform.Translate(position, Space.Self);
            // If background moves left by its repeat width, move it back to start position
            if (transform.position.y < startPos.y - repeatWidth)
            {
                transform.position = startPos;
            }
        }

        internal void Init(BackgroundConfig config)
        {
            _speed = config.TranslationSpeed;
            _bgType = config.Type;
        }
  
    }
}