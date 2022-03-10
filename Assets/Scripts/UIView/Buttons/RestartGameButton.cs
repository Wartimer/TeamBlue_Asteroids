using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace TeamBlue_Asteroids
{
    internal sealed class RestartGameButton : UIButton
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Restart Button Clicked)");
            base.OnPointerClick(eventData);
        }
    }
}