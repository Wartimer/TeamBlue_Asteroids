using System;
using UnityEngine;
using UserInput;

namespace TeamBlue_Asteroids
{
    internal sealed class GameLoop : MonoBehaviour
    {
        private Controllers _controllers;

        private void Awake()
        {
            _controllers = FindObjectOfType<GameStarter>().Controllers;
            
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
        
    }
}