using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    #region SingletonInit
    public static SceneChangeManager Instance { get; private set; }
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

            //CurrentSceneIndex = -1;
            SetSceneIndex();

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }
    #endregion

    #region Fields
    private readonly string[] scenes = new string[]
    {
        "Hallway",
        "Room1",
        "Room2",
        "Room3",
        "Room4",
        "Room5"
    };

    public readonly Vector3 InitialHallwayPos = new Vector3(500, 7, 500);

    public Vector3 LastPlayerPosition { get; set; }
    public int CurrentSceneIndex { get; /*private */set; }
    #endregion fields

    public void SetSceneIndex()
    {
        string name = SceneManager.GetActiveScene().name;

        switch (name)
        {
            case "MainMenu":
                CurrentSceneIndex = -1;
                break;
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

    //IEnumerator LoadSceneAsync(string sceneName)
    //{
    //    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

    //    while (!asyncLoad.isDone)
    //    {
    //        yield return null;
    //    }

    //    SetSceneIndex();

    //    if (CurrentSceneIndex == 0)
    //    {
    //        GameObject.FindGameObjectWithTag("Player").transform.position = LastPlayerPosition;
    //    }
    //}

    public void LoadRoom(int targetRoomNr)
    {
        try
        {
            //switch (targetRoomNr)
            //{
            //    case 1:
            //      //set to pos1
            //    case 2:
            //      //set to pos2
            //    ...
            //}

            if (ProgressManager.Instance.UnlockedRooms[targetRoomNr - 1])
            {
                //StartCoroutine(LoadSceneAsync(scenes[targetRoomNr]));
                SceneManager.LoadScene(scenes[targetRoomNr]);
            }
            else
            {
                Debug.Log("Room inaccessible, complete previous rooms.");
            }
        }
        catch (NullReferenceException ex)
        {
            Debug.LogException(ex);
        }
        catch (Exception ex)
        {
            Debug.Log("Invalid room. Error:" + ex.Message);
        }
    }

    public void LoadMainScene()
    {
        //StartCoroutine(LoadSceneAsync(scenes[0]));
        SceneManager.LoadScene(scenes[0]);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetSceneIndex();

        if (IsMainScene())
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = LastPlayerPosition;
        }
    }

    private bool IsMainScene()
    {
        return CurrentSceneIndex == 0;
    }

    public void UpdateLastPlayerPosition(Vector3 position)
    {
        LastPlayerPosition = position;
    }

    public void ResetPosition()
    {
        LastPlayerPosition = InitialHallwayPos;
    }
}
