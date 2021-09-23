using System;
using System.Collections;
using System.Collections.Generic;
using GameSettingsManagement;
using GameSettingsManagement.PlayerInfoManagement;
using TMPro;
using UnityEngine;

public class PodiumScript : MonoBehaviour
{
    //todo naprawić
    [Serializable]
    private struct PodiumPlace
    {
        public GameObject TankDummy;
        public TextMeshPro TextMeshPro;
    }

    [SerializeField] private TextMeshPro header;
    [SerializeField] private PodiumPlace[] places = new PodiumPlace[4];

    private GameObject playerSettings;
    private PlayerInfoManager playerInfoManager;

    
    
    private void Awake()
    {
        playerSettings = GameObject.Find("GameSettings");
        if (playerSettings == null)
        {
            Debug.LogError("No settings game object (You need to start a game from Lobby)");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerInfoManager = playerSettings.GetComponent<PlayerInfoManager>();

        var scoreBoard = playerInfoManager.GetScoreBoard();
        header.text = "Winner is <color=#" + ColorUtility.ToHtmlStringRGB(scoreBoard[0].Color) + ">" + scoreBoard[0].Name;

        for (int i = 0; i < scoreBoard.Count; i++)
        {
            var playerComponent = places[i].TankDummy.GetComponent<Player>();
            playerComponent.playerInfo = scoreBoard[i];
            playerComponent.ApplyColor();
            places[i].TextMeshPro.text = playerComponent.playerInfo.score.ToString();
        }

        for (int i = scoreBoard.Count; i < 4; i++)
        {
            places[i].TankDummy.SetActive(false);
            places[i].TextMeshPro.gameObject.SetActive(false);
        }
    }

}
