using UnityEngine;

namespace TeamBlue_Asteroids
{
    [CreateAssetMenu(fileName = "PlayerModel", menuName = "Model/Player", order = 51)]
    internal class PlayerModel : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _hitPoints;
        [SerializeField] private int _armour;

        internal float Speed => _speed;
        internal int HitPoints => _hitPoints;
        internal int Armour => _armour;
    }
}