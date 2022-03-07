using UnityEngine;

namespace TeamBlue_Asteroids
{
    [CreateAssetMenu(fileName = "UnitConfig", menuName = "Configs/UnitConfigs/UnitConfig", order = 51)]
    internal class UnitConfig : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _hitPoints;
        [SerializeField] private int _armour;
        [SerializeField] private int _collisionDamage;
        
        internal float Speed => _speed;
        internal int HitPoints => _hitPoints;
        internal int Armour => _armour;
        internal int CollisionDamage => _collisionDamage;
    }
}