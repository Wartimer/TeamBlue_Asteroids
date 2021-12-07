using UnityEngine;
using Random = UnityEngine.Random;

namespace TeamBlue_Asteroids
{
    internal class EnemyView : InteractiveObject, IDamagable, IMove, IEnemy
    {
        private float _speed;
        private float _rotationSpeed;
        private int _hitpoints;
        private int _damage;
        [SerializeField] private EnemyModel _enemyModel;

        public int HitPoints => _hitpoints;
        public float Speed => _speed;
        public int Damage => _damage;
        
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
            if (HitPoints > 0)
                _hitpoints -= amount;
            if (HitPoints <= 0)
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
            _hitpoints = _enemyModel.HitPoints;
            _damage = _enemyModel.Damage;         
            _collider = GetComponent<Collider>();
        }

    }
}