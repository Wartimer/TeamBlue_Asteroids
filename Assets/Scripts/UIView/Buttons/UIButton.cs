using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TeamBlue_Asteroids
{
    public class UIButton : MonoBehaviour, IPointerClickHandler
    {
        public event Action UIButtonClick;
        
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            StartCoroutine(ClickDelay());
            UIButtonClick?.Invoke();
        }
        
        protected IEnumerator ClickDelay()
        {
           yield return new WaitForSeconds(0.75f);
        }
    }
}