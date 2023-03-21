using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text promptTextUI;


    public void UpdatePromptText(string promptMessage)
    {
        promptTextUI.text = promptMessage;
    }
}