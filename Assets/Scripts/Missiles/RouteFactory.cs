using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal class RouteFactory
    {
        private readonly Transform _player;
        private readonly RouteData _data;
        
        internal RouteFactory(Transform player, RouteData data)
        {
            _player = player;
            _data = data;
        }       
        
        internal Transform CreateRoute(int routeId, Vector3 position)
        {
            var route = _data.GetRoute(routeId).transform;
            route.position = position;
            return route;
        }
    }
}