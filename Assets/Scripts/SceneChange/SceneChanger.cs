using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private static readonly string[] scenes = new string[]
    {
        "Hallway",
        "Room1",
        "Room2",
        "Room3",
        "Room4",
        "Room5"
    };

    //put script on door, and assign currentRoomDoorNr from editor
    [SerializeField]
    private int targetRoomNr;

    [SerializeField]
    private GameObject player;

    private void Start()
    {
        if (ProgressManager.Instance.CurrentSceneIndex == 0)
        {
            player.transform.localPosition = ProgressManager.Instance.LastPosition;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            changeScene();
        }
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void loadRoom()
    {
        try
        {
            if (ProgressManager.Instance.UnlockedRooms[targetRoomNr - 1])
            {
                ProgressManager.Instance.LastPosition = player.transform.localPosition - new Vector3(0, 0, 5);
                StartCoroutine(LoadSceneAsync(scenes[targetRoomNr]));
            }
            else
            {
                Debug.Log("Room inaccessible, complete previous rooms.");
            }
        }
        catch (Exception ex)
        {
            Debug.Log("Invalid room. Error:" + ex.Message);
        }
    }

    public void loadMainScene()
    {
        StartCoroutine(LoadSceneAsync(scenes[0]));
        //player.transform.localPosition = ProgressManager.Instance.LastPosition;
    }

    public void changeScene()
    {
        Debug.Log("Room before: " + ProgressManager.Instance.CurrentSceneIndex);

        if (ProgressManager.Instance.CurrentSceneIndex == 0)
        {
            ProgressManager.Instance.CurrentSceneIndex = targetRoomNr;
            loadRoom();
            //Debug.Log("name of room now is: " + SceneManager.GetActiveScene().name);
        }
        else
        {
            ProgressManager.Instance.CurrentSceneIndex = 0;
            loadMainScene();
        }

        //ProgressManager.Instance.setSceneIndex();

        Debug.Log("Room after: " + ProgressManager.Instance.CurrentSceneIndex);
    }
}
