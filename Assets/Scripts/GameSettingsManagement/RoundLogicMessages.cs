using System;
using UnityEngine;

namespace GameSettingsManagement
{
	public class RoundLogicMessages : MonoBehaviour
	{
		[SerializeField] private EndRoundMessage endRoundMessage;
		
		private RoundLogic roundLogic;
		private void Start()
		{
			roundLogic = GetComponent<RoundLogic>();
			roundLogic.OnRoundEndEvent += OnRoundEndMessage;
			endRoundMessage.HideMessage();
		}

		void OnRoundEndMessage(string header, string message)
		{	
			endRoundMessage.SetMessage(header,message);
			endRoundMessage.ShowMessage();
		}
	}
}