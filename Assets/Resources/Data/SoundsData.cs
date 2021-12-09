using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TeamBlue_Asteroids
{

    [CreateAssetMenu(fileName = "SoundsData", menuName = "Data/SoundsData", order = 51)]
    internal class SoundsData : ScriptableObject
    {
        [Serializable]

        private struct SoundsInfo
        {
            public SoundsType Type;
        }

        [SerializeField] private List<SoundsInfo> _soundsInfos;

    }
}
