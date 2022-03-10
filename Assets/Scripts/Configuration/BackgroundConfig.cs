using UnityEngine;

namespace TeamBlue_Asteroids
{
    [CreateAssetMenu(fileName = "BackgroundConfig", menuName = "Configs/BackgroundConfigs", order = 51)]
    internal sealed class BackgroundConfig : ScriptableObject
    {
        [field: SerializeField] private BgType _type;
        [field: SerializeField] private float _translationSpeed;

        internal float TranslationSpeed => _translationSpeed;
        internal BgType Type => _type;
    }
}