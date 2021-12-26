using System;
using TeamBlue_Asteroids;
using UnityEngine;

namespace UserInput
{
    internal sealed class PCInputKeyController : IUserKeyInputProxy, IExecute
    {
        public event Action<KeyCode> KeyPressed;
        
        private KeyCode _key;

        public void Execute(float time)
        {
            if (Input.GetKeyDown(KeyManager.Pause))
            {
                _key = KeyManager.Pause;
                KeyPressed?.Invoke(_key);
            }
        }
    }
}