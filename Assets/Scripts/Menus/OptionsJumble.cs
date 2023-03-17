using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//ADD OPTION TO DEACTIVATE THIS(might be hard to read for some people)
public class OptionsJumble : MonoBehaviour
{
    private string originalText;

    public void Awake()
    {
        originalText = this.GetComponent<Text>().text;
    }

    private void OnEnable()
    {
        StartCoroutine("ShuffleLetter");
    }

    IEnumerator ShuffleLetter()
    {
        while (true)
        {
            char[] text = this.GetComponent<Text>().text.ToCharArray();

            char temp;
            int randIndex;
            for (int i = 0; i < text.Length; i++)
            {
                randIndex = Random.Range(0, text.Length - i);

                temp = text[i];
                text[i] = text[randIndex];
                text[randIndex] = temp;
            }

            this.GetComponent<Text>().text = new string(text);
            yield return new WaitForSecondsRealtime(1f);

            this.GetComponent<Text>().text = originalText;
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}
