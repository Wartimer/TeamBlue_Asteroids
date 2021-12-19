using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    [CreateAssetMenu(fileName = "UIData", menuName = "Data/UIData", order = 51)]
    internal class UIData : ScriptableObject
    {
        [Serializable]

        private struct UIInfo
        {
            public UiType Type;
            public GameObject gameObject;
        }

        [SerializeField] private List<UIInfo> _uiInfos;

        public GameObject CreateUiElement(UiType Type)
        {
            var uiPrefab = _uiInfos.FirstOrDefault(info => info.Type == Type);
            if(uiPrefab.gameObject == null)
            {
                throw new InvalidOperationException($"Prefab of UI type {Type} not found");
            }

            return uiPrefab.gameObject;            
        }
    }
}
