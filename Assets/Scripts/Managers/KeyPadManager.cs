using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class KeyPadManager : MonoBehaviour
{
    [SerializeField]
    private int characterLimit = 5;

    [SerializeField]
    private TMP_InputField keyInputField;

    [SerializeField]
    private TMP_Text objectsOrder;

    [SerializeField]
    private UnityEvent unlockEvent;

    [SerializeField]
    private InteractableStorage[] interactableStorages;

    private char[] passCode;

    private char[] leversOrder;

    private readonly string wrongPrompt = "WRONG";
    private readonly string correctPrompt = "CORRECT";

    private void Start()
    {
        keyInputField.characterLimit = characterLimit;

        passCode = getRandomPIN();

        leversOrder = getRandomLeverOrder();
        objectsOrder.text = new string(leversOrder);

        setLeversData();
    }

    private void setLeversData()
    {
        Stack<int> digitsNotInPass = new Stack<int>();
        for (int i = 0; i <= 9; i++)
        {
            char digitChar = (char)('0' + i);
            if (!passCode.Contains(digitChar))
            {
                digitsNotInPass.Push(i);
            }
        }

        for (int i = 0; i < characterLimit; i++)
        {
            interactableStorages[leversOrder[i] - '0' - 1].keypadButton = passCode[i] - '0';
        }

        for (int i = 0; i < interactableStorages.Length; i++)
        {
            if (!leversOrder.Contains((char)('0' + i + 1)))
            {
                interactableStorages[i].keypadButton = digitsNotInPass.Pop();
            }
        }
    }

    private char[] getRandomNrCharArray(int rangeBegin, int rangeEnd)
    {
        char[] chars = new char[characterLimit];

        for (int i = 0; i < characterLimit; i++)
        {
            char nrToAdd = ' ';
            do
            {
                nrToAdd = (char)('0' + Random.Range(rangeBegin, rangeEnd));

            } while (chars.Contains(nrToAdd));

            chars[i] = nrToAdd;
        }

        return chars;
    }

    private char[] getRandomPIN()
    {
        return getRandomNrCharArray(0, 9);
    }

    private char[] getRandomLeverOrder()
    {
        return getRandomNrCharArray(1, interactableStorages.Count());
    }



    public void PressButtonWithKey(int key)
    {
        if (keyInputField.text == wrongPrompt)
        {
            resetInputField();
        }

        if (keyInputField.text.Length < keyInputField.characterLimit)
        {
            keyInputField.text += key;

            AudioManager.Instance.PlayButtonSound(key);
        }
    }

    public void EnterButton()
    {
        if (keyInputField.text != correctPrompt)
        {
            if (new string(passCode) == keyInputField.text)
            {
                unlockEvent.Invoke();

                keyInputField.text = correctPrompt;
            }
            else
            {
                keyInputField.text = wrongPrompt;

            }
        }
    }

    public void BackspaceButton()
    {
        if (keyInputField.text != correctPrompt)
        {
            if (keyInputField.text != wrongPrompt)
            {
                if (keyInputField.text != string.Empty)
                {
                    keyInputField.text = keyInputField.text.Remove(keyInputField.text.Length - 1);
                }
            }
            else
            {
                resetInputField();
            }
        }
    }

    private void resetInputField()
    {
        keyInputField.text = string.Empty;
    }
}
