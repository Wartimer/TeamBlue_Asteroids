using System;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal abstract class InteractiveObject : MonoBehaviour, IDisposable
    {

        private bool _isInteractable;
        protected Rigidbody _rigidBody;
        protected PlayerView _player;
        
        protected bool IsInteractable
        {
            get => _isInteractable;
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }

        protected abstract void Interaction();

        protected abstract void OnTriggerEnter(Collider other);


        public virtual void Dispose()
        {
            Destroy(gameObject);
        }
    }
}