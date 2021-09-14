using GameSettingsManagement.PlayerInfoManagement;
using UnityEngine;

namespace GameSettingsManagement
{
    public class Player : MonoBehaviour
    {
        public PlayerInfo playerInfo;
        
        public void ApplyColor()
        {
            var renderers = GetComponentsInChildren<MeshRenderer>();
            foreach (var renderer in renderers)
            {
                renderer.material.color = playerInfo.Color;
            }
        }
    }
}
