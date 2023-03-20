using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class KeyPadManager : MonoBehaviour
{
    [SerializeField]
    private string passCode;

    [SerializeField]
    private int characterLimit = 5;

    [SerializeField]
    TMP_InputField keyInputField;

    [SerializeField]
    private UnityEvent unlockEvent;

    private int inputCount;
    private readonly string wrongPrompt = "WRONG";

    private void Start()
    {
        keyInputField.characterLimit = characterLimit;
    }

    public void PressButtonWithKey(int key)
    {
        if (inputCount < keyInputField.characterLimit)
        {
            if (keyInputField.text == wrongPrompt)
            {
                resetInputField();
            }

            keyInputField.text += key;
            inputCount++;

            AudioManager.Instance.PlayButtonSound(key);
        }
    }

    public void enterButton()
    {
        if (passCode == keyInputField.text)
        {
            unlockEvent.Invoke();
        }
        else
        {
            keyInputField.text = wrongPrompt;

        }
    }


    public void cancelButton()
    {
        resetInputField();
    }

    private void resetInputField()
    {
        keyInputField.text = string.Empty;
        inputCount = 0;
    }
}
