using System;
using UnityEngine;


namespace TeamBlue_Asteroids
{
    internal sealed class PlayerAnimationController : IFixedExecute
    {
        
        private PlayerView _player;
        private Animator _animator;              

        public PlayerAnimationController(PlayerView player)
        {          
            _player = player;  
            _animator = _player.gameObject.GetComponent<Animator>();
        }


        public void FixedExecute(float deltaTime)
        {
            if (Input.GetKey(KeyCode.A))
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
            }
        }



    }
}
