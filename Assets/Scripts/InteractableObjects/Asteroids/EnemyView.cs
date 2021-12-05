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

        internal void Execute(float time)
        {
            Rotation(time);
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
        
        public void Rotation(float time)
        {
            transform.Rotate(Vector3.up * (time * _rotationSpeed), 
                Space.World);
            transform.Rotate(Vector3.forward * (time * _rotationSpeed), 
                Space.World);
        }

        private void OnBecameVisible()
        {
           _collider.enabled = true;
        }

        private void OnBecameInvisible()
        {
            _collider.enabled = false;
        }

        private void OnEnable()
        {
            EnemyModelInit();
        }

        private void EnemyModelInit()
        {
            _speed = _enemyModel.Speed;
            _rotationSpeed = Random.Range(-20, 20);
            _hitpoints = _enemyModel.HitPoints;
            _damage = _enemyModel.Damage;
            _rigidBody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

    }
}