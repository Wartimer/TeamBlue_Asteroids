using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData", order = 51)]
    internal class PlayerData : ScriptableObject
    {
        [Serializable]
        private struct PlayerInfo
        {
            public PlayerType Type;
            public GameObject PlayerPrefab;
        }
        
        [SerializeField] private List<PlayerInfo> _playerInfos;

        public GameObject GetPlayer(PlayerType type)
        {
            var playerInfo = _playerInfos.FirstOrDefault(info => info.Type == type);
            if (playerInfo.PlayerPrefab == null)
            {
                throw new InvalidOperationException($"Prefab of Player type {type} not found");
            }

            var obj = Instantiate(playerInfo.PlayerPrefab);
            return obj;
        }
    }
}