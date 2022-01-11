using UnityEngine.EventSystems;

namespace TeamBlue_Asteroids
{
    public class QuitGameButton : UIButton
    {
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            QuitGame();
        }
        
        
        private void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}