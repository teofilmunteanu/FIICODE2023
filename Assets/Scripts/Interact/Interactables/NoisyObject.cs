using UnityEngine;

public class NoisyObject : Interactable
{
    [SerializeField]
    private PlayerUI playerUI;

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
        Debug.Log("sprite inspector");
        playerUI.ActivateSpriteInspector();

    }
}
