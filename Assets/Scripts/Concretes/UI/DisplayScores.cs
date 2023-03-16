using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BallBlastReplika.UI
{
    public class DisplayScores : MonoBehaviour
    {
        TextMeshProUGUI _scoreText;

        private void Awake()
        {
            _scoreText= GetComponent<TextMeshProUGUI>();    
        }
        private void Start()
        {
            GameManager.Instance.OnScoreChanged += HandleScoreChange;
            HandleScoreChange();
        }
        private void OnDisable()
        {
            GameManager.Instance.OnScoreChanged -= HandleScoreChange;
        }
        private void HandleScoreChange(int score = 0)
        {
            _scoreText.text = $"{score}";
        }
    }

}