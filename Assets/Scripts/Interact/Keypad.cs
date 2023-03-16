using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    Animator keypadAnimator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        Debug.Log("Interact with " + gameObject.name);
        keypadAnimator.SetTrigger("Open");
    }
}
