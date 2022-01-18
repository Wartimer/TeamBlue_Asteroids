using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace TeamBlue_Asteroids
{

    [CreateAssetMenu(fileName = "BuffData", menuName = "Data/BuffData", order = 51)]

    internal class BuffData : ScriptableObject
    {
        [Serializable]

        private struct BuffInfo
        {
            public BuffType type;
            public GameObject gameObject;
        }

        [SerializeField] private List<BuffInfo> _buffInfos;

        public GameObject CreateBuffElement(BuffType type)
        {
            var buffPrefab = _buffInfos.FirstOrDefault(info => info.type == type);

            if(buffPrefab.gameObject == null)
            {
                throw new InvalidOperationException($"Prefab of UI type {type} not found");
            }

            return buffPrefab.gameObject;
        }
    }
}
