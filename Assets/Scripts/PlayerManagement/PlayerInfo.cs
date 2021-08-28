using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerManagement
{
    public enum PlayerController
    {   
        None,
        MouseAndKeyboard,
        Gamepad0,
        Gamepad1,
        Gamepad2,
        Gamepad3
    }
    public class PlayerInfo : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        
        [SerializeField] private Transform spawnPointContainer;
        [SerializeField] private PlayerController[] playerController;

        private PlayerInputManager playerInputManager;

        private List<Transform> spawnPointsList;

        public void InitialiseGame()
        {
            FindAllSpawnPoints();

            playerInputManager = GetComponent<PlayerInputManager>();
            var gamepads = Gamepad.all;
            Debug.Log("Gamepad count: " + gamepads.Count);
            var i = -1;
            foreach (var gamepad in gamepads)
            {
                if (i == -1)
                {
                    i++;
                    continue;
                }
                Debug.Log("Gamepad type: " + gamepad.displayName );
                var player = PlayerInput.Instantiate(playerPrefab, controlScheme: "Gamepad", pairWithDevice: gamepad);
                
                var transform1 = player.transform;
                transform1.position = spawnPointsList[i].position;
                transform1.rotation = spawnPointsList[i].rotation;
                i++;
            }
        }

        private void FindAllSpawnPoints()
        {
            spawnPointsList = new List<Transform>();
            foreach (Transform child in spawnPointContainer)
            {
                spawnPointsList.Add(child);
            }
        }

        private void Start()
        {
            InitialiseGame();
        }

        void OnPlayerJoined(PlayerInput playerInput)
        {
            var playerGameObject = playerInput.gameObject;
            playerGameObject.transform.position = spawnPointContainer.position;
            playerGameObject.transform.rotation = spawnPointContainer.rotation;
        }
    }
}