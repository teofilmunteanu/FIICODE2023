using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class KeyPadManager : MonoBehaviour
{
    [SerializeField]
    private string passCode;

    [SerializeField]
    private int characterLimit=5;

    [SerializeField]
    TMP_InputField keyInputField;

    [SerializeField]
    private UnityEvent unlockEvent;

    private int inputCount;

    private void Start()
    {
        keyInputField.characterLimit = characterLimit;
    }

    public void keyButton(string key)
    {
        if(inputCount< keyInputField.characterLimit)
        {
            keyInputField.text += key;
            inputCount++;
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
            keyInputField.text = "WRONG";
            
        }
    }


    public void cancelButton()
    {
        resetInpuField();
    }

    private void resetInpuField()
    {
        keyInputField.text = string.Empty;
        inputCount = 0;
    }
}
