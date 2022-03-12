using System;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TeamBlue_Asteroids
{
    internal class EnemyView : InteractiveObject, IMove
    {
        internal event Action<EnemyView> EnemyDead;
        private UnitStats _enemyStats;
        
        [SerializeField] private UnitConfig _enemyConfig;
        
        internal UnitStats EnemyStats => _enemyStats;
        
        public void Move(Vector3 position)
        {
            transform.position += position;
        }
        
        protected virtual void OnEnable()
        {
            EnemyInit();
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            _player = other.GetComponent<PlayerView>();
            Interaction();
            Dispose();
        }

        protected override void Interaction()
        {
            _player.PlayerStats.TakeDamage(_enemyStats.CollisionDamage);
            
        }

        protected virtual void EnemyInit()
        {
            _enemyStats = new EnemyStats(_enemyConfig, this);
        }
        
        public override void Dispose()
        {
            EnemyDead?.Invoke(this);
            base.Dispose();
        }
    }
}