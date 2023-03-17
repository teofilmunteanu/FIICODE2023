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

    public override void Interact()
    {
        keypadAnimator.SetTrigger("Open");
    }
}
