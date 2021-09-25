using TMPro;
using UnityEngine;

namespace Lobby
{
    public class GameSettingsChanger : MonoBehaviour
    {
        [SerializeField] private int defaultRequiredWins = 15;
        [SerializeField] private TextMeshProUGUI displayTextMesh;
        [SerializeField] private RoundManager roundManager;
    
    
        private int requiredWins;

        public void IncreaseRequiredWins(int howMany)
        {
            requiredWins += howMany;
            requiredWins = (int)Mathf.Repeat(requiredWins, 26);
            UpdateDisplay();
            UpdateGameSettings();
        }
        private void UpdateDisplay()
        {
            displayTextMesh.text = requiredWins.ToString();
        }
        private void UpdateGameSettings()
        {
            roundManager.requiredScore = requiredWins;
        }
        private void Start()
        {
            requiredWins = defaultRequiredWins;
            UpdateDisplay();
            UpdateGameSettings();
        }
    }
}
