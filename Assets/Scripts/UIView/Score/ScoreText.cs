using UnityEngine;
using System;
using UnityEngine.UI;
namespace TeamBlue_Asteroids
{
    public class ScoreText : MonoBehaviour
    {
        private int score = 0;
        public event Action DisplayWonGame;
        
        private void Start()
        {
            GlobalEventManager.OnEnemyKillded.AddListener(ScoreIncrease);
        }
        private void ScoreIncrease()
        {
            score++;
            GetComponent<Text>().text = "Score: " + score;
            
            if(score >= 100)
            {
                Debug.Log("Won!");
                DisplayWonGame?.Invoke();
            }
        }
    }
}
