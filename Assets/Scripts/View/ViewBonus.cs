using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Maze
{
    public class ViewBonus
    {
        private TextMeshProUGUI _bonusLabel;

        public ViewBonus(GameObject bonusLabelPrefab)
        {
            _bonusLabel = bonusLabelPrefab.GetComponent<TextMeshProUGUI>();
            _bonusLabel.text = string.Empty;
        }

        public void Display(int value)
        {
            _bonusLabel.text = $"Bonus: {value}";
        }
    }
}