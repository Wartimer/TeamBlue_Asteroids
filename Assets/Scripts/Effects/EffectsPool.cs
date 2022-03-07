using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TeamBlue_Asteroids
{
    internal class EffectsPool : IDisposable
    {
        private readonly Stack<EffectView> _stack = new Stack<EffectView>();
        private Transform _root;
        private Vector3 _point;
        private Vector3 _rootPosition;
        private EffectFactory _effectFactory;

        internal EffectsPool(EffectFactory effectFactory)
        {
            _root = Object.FindObjectOfType<EffectsRoot>().transform;
            _rootPosition = _root.position;
            _effectFactory = effectFactory;
        }

        internal EffectView Pop(Vector3 position)
        {
            _point = position;
            EffectView effect;
            if (_stack.Count == 0)
            {
                effect = Object.Instantiate(_effectFactory.CreateEffect(EffectType.Explosion), _point, Quaternion.identity).AddComponent<EffectView>();
            }
            else
            {
                effect = _stack.Pop();
            }
            effect.gameObject.SetActive(true);
            effect.transform.SetParent(null);
            effect.transform.position = _point;
            return effect;
        }

        internal void Push(EffectView effect)
        {
            _stack.Push(effect);
            var effectTransform = effect.transform;
            effectTransform.SetParent(_root);
            effectTransform.position = _rootPosition;
            effectTransform.gameObject.SetActive(false);
        }

        public void Dispose()
        {
            for (var i = 0; i < _stack.Count; i++)
            {
                var gameObject = _stack.Pop();
                Object.Destroy(gameObject);
            }
            Object.Destroy(_root);
        }
    }
}