using UnityEngine;
using UnityEngine.SceneManagement;

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

            PaperCollectedInRoom = new bool[nrOfRooms];
            //for testing I set first two to "true", only set the first one
            UnlockedRooms = new bool[] { true, true, false, false, false };
            setSceneIndex();
            LastPosition = new Vector3(500, 7, 500);
        }
    }

    private const int nrOfRooms = 5;

    public bool[] UnlockedRooms { get; set; }
    public bool[] PaperCollectedInRoom { get; set; }
    public Vector3 LastPosition { get; set; }


    public int CurrentSceneIndex { get; /*private */set; }

    public void setSceneIndex()
    {
        string name = SceneManager.GetActiveScene().name;

        switch (name)
        {
            case "Hallway":
                CurrentSceneIndex = 0;
                break;
            case "Room1":
                CurrentSceneIndex = 1;
                break;
            case "Room2":
                CurrentSceneIndex = 2;
                break;
            case "Room3":
                CurrentSceneIndex = 3;
                break;
            case "Room4":
                CurrentSceneIndex = 4;
                break;
            case "Room5":
                CurrentSceneIndex = 5;
                break;
            default:
                return;
        }
    }
}
