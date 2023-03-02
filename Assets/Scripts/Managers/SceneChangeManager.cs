using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public int currentRoomDoorNr;

    //put script on door, and assign currentRoomDoorNr from editor

    public void loadRoom()
    {
        if (currentRoomDoorNr == 1)
        {
            SceneManager.LoadScene("Room1");
        }
        else
        {
            if (ProgressManager.Instance.lastUnlockedRoom >= currentRoomDoorNr)
            {
                string sceneName = "Room" + currentRoomDoorNr;
                SceneManager.LoadScene(sceneName);
                ProgressManager.Instance.currentSceneIndex = currentRoomDoorNr;
            }
            else
            {
                Debug.Log("Room inaccessible, complete previous rooms.");
            }

            Debug.Log("Current room: " + ProgressManager.Instance.currentSceneIndex);
        }
    }
}
