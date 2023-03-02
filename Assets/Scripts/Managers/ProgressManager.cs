using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            paperCollectedInRoom = new bool[nrOfRooms];
            lastUnlockedRoom = 1;
            currentSceneIndex = 0;
        }
    }

    private int nrOfRooms = 5;

    public int currentSceneIndex;
    public int lastUnlockedRoom;
    public bool[] paperCollectedInRoom;
}
