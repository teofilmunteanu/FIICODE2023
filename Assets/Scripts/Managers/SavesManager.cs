using Assets.Scripts.DTOs;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public static class SavesManager
    {

        private static string savePath = Application.persistentDataPath + "/progress.save";

        public static void SaveProgress()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.Create);

            ProgressManager progressManager = ProgressManager.Instance;
            SceneChangeManager sceneChangeManager = SceneChangeManager.Instance;

            ProgressDTO progressDTO = new ProgressDTO(progressManager.CompletedRooms, progressManager.PaperCollectedInRoom, sceneChangeManager.LastPlayerPosition);
            binaryFormatter.Serialize(stream, progressDTO);

            Debug.Log("Saved in " + Application.persistentDataPath);

            stream.Close();
        }

        public static ProgressDTO LoadProgress()
        {
            if (File.Exists(savePath))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(savePath, FileMode.Open);

                ProgressDTO progressDTO = (ProgressDTO)binaryFormatter.Deserialize(stream);

                stream.Close();

                return progressDTO;
            }
            else
            {
                Debug.LogError("Not found");
                return null;
            }
        }
    }
}
