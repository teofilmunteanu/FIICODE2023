using UnityEngine;

namespace Assets.Scripts.DTOs
{
    [System.Serializable]
    public class ProgressDTO
    {
        public bool[] CompletedRooms { get; set; }
        public bool[] PaperCollectedInRoom { get; set; }
        public float[] Position { get; set; }

        public ProgressDTO(bool[] completedRooms, bool[] papersCollectedInRoom, Vector3 lastPlayerPos)
        {

            CompletedRooms = completedRooms;
            PaperCollectedInRoom = papersCollectedInRoom;
            Position = new float[]
            {
                lastPlayerPos.x,
                lastPlayerPos.y,
                lastPlayerPos.z
            };
        }
    }
}
