using System;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private Data _data;
        [SerializeField] private RouteData _routeData;
        private Controllers _controllers;
        
        private void Start()
        {
            _controllers = new Controllers();
            new GameInitialization(_controllers, _data, _routeData);
            _controllers.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateExecute(deltaTime);
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.FixedExecute(deltaTime);
        }

        private void OnDestroy()
        {
           
        }
    }
}