using System;
using UnityEngine;


namespace TeamBlue_Asteroids
{
    internal sealed class PlayerAnimationController : IFixedExecute, ICleanup, IRemoveFromControllers
    {
        public event Action<IController> PlayerRemoved;
        
        private PlayerView _player;
        private Animator _animator;
        
        private float _horizontal;
        private IUserInputProxy _horizontalInputProxy;
        private static readonly int Turn = Animator.StringToHash("Turn");

        public PlayerAnimationController(IUserInputProxy horizontalInputProxy, PlayerView player)
        {          
            _player = player;  
            _animator = _player.gameObject.GetComponent<Animator>();
            _horizontalInputProxy = horizontalInputProxy;
            
            _horizontalInputProxy.AxisChange += OnHorizontalAxisChange;
            _player.PlayerDestroyed += Cleanup;
        }

        private void OnHorizontalAxisChange(float value)
        {
            _horizontal = value * 0.4f;
            Debug.Log(_horizontal);
        }
        
        public void FixedExecute(float deltaTime)
        {
            
            _animator.SetFloat(Turn, _horizontal);
            
            /*if (Input.GetKey(KeyCode.A))
            {
                _animator.SetFloat("Turn", -1);
            }

            if (Input.GetKey(KeyCode.D))
            {
                _animator.SetFloat("Turn", 1);
            }

            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                _animator.SetFloat("Turn", 0);
            }*/
        }

        public void Cleanup()
        {
            _player.PlayerDestroyed -= Cleanup;
            _horizontalInputProxy.AxisChange -= OnHorizontalAxisChange;
            PlayerRemoved?.Invoke(this);
        }

    }
}
