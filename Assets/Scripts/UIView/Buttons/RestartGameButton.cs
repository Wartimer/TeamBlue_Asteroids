using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace TeamBlue_Asteroids
{
    internal sealed class RestartGameButton : UIButton
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            StartCoroutine(ClickDelay());
            SceneManager.LoadScene(0);
            
        }
    }
}