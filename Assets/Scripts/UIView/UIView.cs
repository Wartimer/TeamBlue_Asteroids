using UnityEngine;
using System;
using Asteroids;
using Object = UnityEngine.Object;

namespace TeamBlue_Asteroids
{
    public class UIView : IUIView, IDisposable
    {
        protected GameObject _uiElement;
        
        

        internal UIView(GameObject element)
        {
            _uiElement = element;
        }
        
        public void Show()
        {
           _uiElement.SetActive(true);
        }
        
        public void Hide()
        {
            _uiElement.SetActive(false);
        }

        public void Dispose()
        {
            Object.Destroy(_uiElement);
        }
    }
}
