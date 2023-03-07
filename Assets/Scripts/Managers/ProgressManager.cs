using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    #region SingletonInit
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
        }
    }
    #endregion

    private const int nrOfRooms = 5;

    public bool[] UnlockedRooms { get; set; }
    public bool[] PaperCollectedInRoom { get; set; }

    public void CompleteRoom()
    {
        //set as complete
        //unlock next room

        //make prefabs that complete rooms
    }

    public void AddFoundPaper()
    {
        //add paper to PaperCollectedInRoom by room

        //make paper prefabs
    }
}
