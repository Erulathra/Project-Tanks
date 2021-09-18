using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EndRoundMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI header;
    [SerializeField] private TextMeshProUGUI message;

    public void SetMessage(string headerText, string messageText)
    {
        header.text = headerText;
        message.text = messageText;
    }

    public void ShowMessage()
    {
        header.transform.parent.gameObject.SetActive(true);
    }

    public void HideMessage()
    {
        header.transform.parent.gameObject.SetActive(false);
    }
}
