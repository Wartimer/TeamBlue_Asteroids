using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TeamBlue_Asteroids
{
    internal class EnemyView : InteractiveObject, IDamagable, IMove
    {
        internal event Action<EnemyView> EnemyDead;
        
        private float _speed;
        private float _rotationSpeed;
        private int _hitPoints;
        private int _damage;
        [SerializeField] private EnemyModel _enemyModel;

        internal EnemyModel Model
        {
            set => _enemyModel = value;
        }

        internal virtual void Execute(float time)
        {
            Move(time);
        }

        public void TakeDamage(int amount)
        {
            if (_hitPoints > 0)
                _hitPoints -= amount;
            if (_hitPoints <= 0)
                Dispose();
        }
        
        protected override void Interaction()
        {
            
        }
        
        public void Move(float time)
        {
            transform.position += (Vector3.down * _speed * time);
        }
        
        protected virtual void OnEnable()
        {
            EnemyModelInit();
        }

        protected virtual void EnemyModelInit()
        {
            _speed = _enemyModel.Speed;
            _hitPoints = _enemyModel.HitPoints;
            _damage = _enemyModel.Damage;         
            _collider = GetComponent<Collider>();
        }

        public override void Dispose()
        {
            EnemyDead?.Invoke(this);
            base.Dispose();
        }
    }
}