using System;
using UnityEngine;

namespace UnityTemplateProjects.InteractableObjects
{
    internal abstract class InteractiveObject : MonoBehaviour, IDisposable
    {
        private bool _isInteractable;
        [SerializeField] protected Rigidbody _rigidBody;

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

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player")) return;
            Interaction();
            IsInteractable = false;
            Dispose();
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}