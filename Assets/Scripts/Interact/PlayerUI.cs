using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Text promptTextUI;


    public void UpdatePromptText(string promptMessage)
    {
        promptTextUI.text = promptMessage;
    }
}