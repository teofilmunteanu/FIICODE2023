using Assets.Scripts.DTOs;
using Assets.Scripts.Managers;
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
            CompletedRooms = new bool[] { false, false, false/*, false, false */};
        }
    }
    #endregion

    private const int nrOfRooms = 3;

    public bool[] CompletedRooms { get; set; }
    public bool[] PaperCollectedInRoom { get; set; }


    public void ResetProgress()
    {
        CompletedRooms = new bool[] { false, false, false/*, false, false */};
        PaperCollectedInRoom = new bool[nrOfRooms];
        SceneChangeManager.Instance.ResetPosition();
    }

    public void LoadProgress()
    {
        //all of these should be taken from save file
        ProgressDTO progresDTO = SavesManager.LoadProgress();

        CompletedRooms = progresDTO.CompletedRooms;
        PaperCollectedInRoom = progresDTO.PaperCollectedInRoom;

        Vector3 lastPosition = new Vector3(progresDTO.Position[0], progresDTO.Position[1], progresDTO.Position[2]);
        SceneChangeManager.Instance.UpdateLastPlayerPosition(lastPosition);
    }

    public void CompleteRoom(int index)
    {
        if (index >= 1 && index <= nrOfRooms)
        {
            CompletedRooms[index - 1] = true;

            SavesManager.SaveProgress();
        }
        //make prefabs that complete rooms
    }

    public void AddFoundPaper(int roomNr)
    {
        PaperCollectedInRoom[roomNr] = true;

        //make paper prefabs
    }
}
