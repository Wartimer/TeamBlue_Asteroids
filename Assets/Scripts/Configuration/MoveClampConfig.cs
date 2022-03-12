using UnityEngine;

namespace TeamBlue_Asteroids
{
    [CreateAssetMenu(fileName = "MoveClampConfig", menuName = "Configs/MoveClampConfig", order = 51)]
    internal class MoveClampConfig : ScriptableObject
    {
        [SerializeField] internal ResolutionType _type;
        [SerializeField] private float _x;
        [SerializeField] private float _y;

        internal ResolutionType Type => _type;
        internal float X => _x;
        internal float Y => _y;
    }
}