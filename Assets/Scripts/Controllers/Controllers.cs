using System.Collections.Generic;
using UnityEngine;

namespace TeamBlue_Asteroids
{
    internal sealed class Controllers : IInitialization, IExecute, ILateExecute, IFixedExecute
    {
        private readonly List<IInitialization> _initializeControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ILateExecute> _lateControllers;
        private readonly List<IFixedExecute> _fixedControllers;

        internal Controllers()
        {
            _initializeControllers = new List<IInitialization>(8);
            _executeControllers = new List<IExecute>(8);
            _lateControllers = new List<ILateExecute>(8);
            _fixedControllers = new List<IFixedExecute>(8);
        }

        internal Controllers Add(IController controller)
        {
            if (controller is IRemoveFromControllers controllerToRemove)
                controllerToRemove.PlayerRemoved += Remove;
            
            if (controller is IInitialization initializeController)
            {
                _initializeControllers.Add(initializeController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }

            if (controller is ILateExecute lateExecuteController)
            {
                _lateControllers.Add(lateExecuteController);
            }
            
            if (controller is IFixedExecute fixedController)
            {
                _fixedControllers.Add(fixedController);
            }

            return this;
        }
        
        internal void Remove(IController controller)
        {
            if (controller is IRemoveFromControllers controllerToRemove)
                controllerToRemove.PlayerRemoved -= Remove;
            
            if (controller is IInitialization initializeController)
            {
                _initializeControllers.Remove(initializeController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Remove(executeController);
            }

            if (controller is ILateExecute lateExecuteController)
            {
                _lateControllers.Remove(lateExecuteController);
            }
            
            if (controller is IFixedExecute fixedController)
            {
                _fixedControllers.Remove(fixedController);
            }
        }
        
        public void Initialization()
        {
            for (var index = 0; index < _initializeControllers.Count; ++index)
            {
                _initializeControllers[index].Initialization();
            }
        }
        
        public void Execute(float deltaTime)
        {
            for (var index = 0; index < _executeControllers.Count; ++index)
            {
                _executeControllers[index].Execute(deltaTime);
            }
        }
        
        public void LateExecute(float deltaTime)
        {
            for (var index = 0; index < _lateControllers.Count; ++index)
            {
                _lateControllers[index].LateExecute(deltaTime);
            }
        }

        public void FixedExecute(float deltaTime)
        {
            for (var index = 0; index < _fixedControllers.Count; ++index)
            {
                _fixedControllers[index].FixedExecute(deltaTime);         
            }
        }
        
        
        
        
    }
}