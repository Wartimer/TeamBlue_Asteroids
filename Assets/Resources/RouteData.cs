using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    [CreateAssetMenu(fileName = "RocketRouteData", menuName = "Data/RocketRouteData", order = 51)]
    internal class RouteData : ScriptableObject
    {
        [Serializable]
        private struct RouteInfo
        {
            public int ID;
            public GameObject Route;
        }
        
        [SerializeField] private List<RouteInfo> _routeInfos;

        public GameObject GetRoute(int routeId)
        {
            var routeInfo = _routeInfos.FirstOrDefault(id => id.ID == routeId);
            if (routeInfo.Route == null)
            {
                throw new InvalidOperationException($"Prefab of Route type {routeId} not found");
            }

            var obj = Instantiate(routeInfo.Route);
            return obj;
        }
    }
}