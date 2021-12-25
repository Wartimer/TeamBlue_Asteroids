using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TeamBlue_Asteroids
{
    public class UIButton : MonoBehaviour, IPointerClickHandler
    {
        public event Action UIButtonClick;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            UIButtonClick?.Invoke();
        }
    }
}