using System.Linq;
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
    TMP_Text objectsOrder;

    [SerializeField]
    private UnityEvent unlockEvent;

    //[SerializeField]
    //private GameObject LockObj;

    private int inputCount;
    private readonly string wrongPrompt = "WRONG";
    private readonly string correctPrompt = "CORRECT";

    private void Start()
    {
        //LockObj.GetComponent<Collider2D>().enabled = true;

        keyInputField.characterLimit = characterLimit;

        objectsOrder.text = "12345";
        //only for testing, should get random nr, but then, should also set the levers sounds
        //getObjectsOrderString();

        //the correct pass should also be randomized(it's given in unity rn)
    }

    public string getObjectsOrderString()
    {
        char[] chars = new char[characterLimit];

        for (int i = 0; i < characterLimit; i++)
        {
            char nrToAdd = ' ';
            do
            {
                nrToAdd = (char)('0' + Random.Range(0, 9));

            } while (chars.Contains(nrToAdd));

            chars[i] = nrToAdd;
        }

        return new string(chars);
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

            //LockObj.GetComponent<Collider2D>().enabled = false;
            keyInputField.text = correctPrompt;
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
