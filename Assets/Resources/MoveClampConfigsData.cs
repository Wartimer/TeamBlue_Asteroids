using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    [CreateAssetMenu(fileName = "MoveClampConfigsData", menuName = "Data/MoveClampData", order = 51)]
    internal sealed class MoveClampConfigsData : ScriptableObject
    {
        [Serializable]
        private struct MoveClampConfigInfo
        {
            public ResolutionType Type;
            public MoveClampConfig Config;
        }
            
        [Header("MoveClamp Configs")]
        [SerializeField] private List<MoveClampConfig> _moveClampConfigs;
        
        internal MoveClampConfig GetMoveClampConfig(ResolutionType type)
        {
            var moveClampConfigInfo = _moveClampConfigs.FirstOrDefault(info => info.Type == type);
            if(moveClampConfigInfo == null)
                throw new InvalidOperationException($"BG config type {type} not found");
                
            return moveClampConfigInfo;
        }
        
    }
}