using UnityEngine;
using UnityEngine.Tilemaps;

public class Room3ButtonManager : MonoBehaviour
{
    #region Singleton Init
    public static Room3ButtonManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    [SerializeField] GameObject[] buttons;
    [SerializeField] TilemapRenderer wallsTilemap;
    [SerializeField] GameObject finish;

    private int buttonsPressedCount;

    public bool gameFinished;

    public void ButtonPressed()
    {
        buttonsPressedCount++;

        if (buttonsPressedCount == buttons.Length)
        {
            FinishRoom();
        }
    }

    private void FinishRoom()
    {
        wallsTilemap.enabled = false;

        gameFinished = true;

        finish.SetActive(true);

        foreach (var collider in wallsTilemap.GetComponents<Collider2D>())
        {
            collider.enabled = false;
        }
    }
}
