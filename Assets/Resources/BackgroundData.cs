using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    [CreateAssetMenu(fileName = "BackgroundData", menuName = "Data/BackgroundData", order = 51)]
    internal sealed class BackgroundData : ScriptableObject
    {
            [Serializable]
            private struct BackgroundInfo
            {
                public BgType Type;
                public BackgroundView BgPrefab;
            }

            [Serializable]
            private struct BackgroundConfigInfo
            {
                public BgType Type;
                public BackgroundConfig Config;
            }
            
            [Header("BG Prefabs")]
            [SerializeField] private List<BackgroundInfo> _backgroundInfos;
            
            [Header("BG Configs")]
            [SerializeField] private List<BackgroundConfigInfo> _backgroundConfigs;

            
            public BackgroundView GetBackground(BgType type)
            {
                var bgInfo = _backgroundInfos.FirstOrDefault(info => info.Type == type);
                
                if (bgInfo.BgPrefab == null)
                {
                    throw new InvalidOperationException($"BG type {type} not found");
                }
                
                return bgInfo.BgPrefab;
            }

            internal BackgroundConfig GetBgConfig(BgType type)
            {
                var bgInfo = _backgroundConfigs.FirstOrDefault(info => info.Type == type);
                if(bgInfo.Config == null)
                    throw new InvalidOperationException($"BG config type {type} not found");
                
                return bgInfo.Config;
            }
        
    }
}