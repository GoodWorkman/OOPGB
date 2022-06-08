using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Maze
{
    public class ViewEndGame : MonoBehaviour
    {
        private TextMeshProUGUI _endGameLabel;

        public ViewEndGame(GameObject endGamePrefab)
        {
            _endGameLabel = endGamePrefab.GetComponent<TextMeshProUGUI>();
            _endGameLabel.text = string.Empty;
        }

        public void GameOver(string name, Color color)
        {
            _endGameLabel.text = $"Game over. Bonus name: {name}. Color: {color}";
        }
    }
}
