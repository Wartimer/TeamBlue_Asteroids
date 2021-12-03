using System.Collections.Generic;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    [CreateAssetMenu(fileName = "EnemyModel", menuName = "Model/Enemy", order = 51)]
    public class EnemyModel : ScriptableObject
    {
        [SerializeField] private int _hitpoints;
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        internal int HitPoints => _hitpoints;
        internal int Damage => _damage;
        internal float Speed => _speed;
        internal float RotationSpeed => _rotationSpeed;
    }
}