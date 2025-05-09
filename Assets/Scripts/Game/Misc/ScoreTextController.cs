using System;
using Game.Player;
using TMPro;
using UnityEngine;

namespace Game.Misc
{
    public class ScoreTextController : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private double _lastScore;

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            PlayerController.OnScoreChange += UpdateScore;
        }

        private void OnDestroy()
        {
            PlayerController.OnScoreChange -= UpdateScore;
        }

        private void UpdateScore(double score)
        {
            _lastScore = score;
            _text.SetText(score.ToString("F1"));
            _text.color = score < 0 ? Color.red : Color.green;
        }

        public int GetLastDisplayedScore()
        {
            return (int)Math.Round(_lastScore);
        }
    }
}