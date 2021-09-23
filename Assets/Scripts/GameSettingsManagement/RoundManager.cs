using System;
using System.Collections;
using System.Collections.Generic;
using GameSettingsManagement.PlayerInfoManagement;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private SceneLoader.Scene stageScene;
    
    [SerializeField] public int requiredScore = 5;

    private PlayerInfoManager playerInfoManager;
    private IMapManager mapManager;
    public void Start()
    {
        playerInfoManager = GetComponent<PlayerInfoManager>();
        mapManager = GetComponent<IMapManager>();
    }

    public void StartNewGame()
    {
        mapManager.LoadFirstMap();
    }
    
    public void LoadNextMapOrEndTheGame()
    {
        var playerWithHighestScore = playerInfoManager.FindPlayerWithHighestScore();
        if(playerWithHighestScore.score >= requiredScore)
        {
            SceneLoader.TryLoadSceneWithTransition(stageScene);
            return;
        }
        mapManager.LoadNextMap();
    }
}
