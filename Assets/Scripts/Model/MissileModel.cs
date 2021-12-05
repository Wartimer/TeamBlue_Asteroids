using UnityEngine;

namespace TeamBlue_Asteroids
{
    [CreateAssetMenu(fileName = "MissileModel", menuName = "Model/Missile", order = 51)]
    public class MissileModel : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;

        internal float Speed => _speed;
        internal int Damage => _damage;
    }
}