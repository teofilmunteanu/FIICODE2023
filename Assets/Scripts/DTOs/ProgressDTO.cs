using UnityEngine;

namespace Assets.Scripts.DTOs
{
    [System.Serializable]
    public class ProgressDTO
    {
        public bool[] UnlockedRooms { get; set; }
        public bool[] PaperCollectedInRoom { get; set; }
        public float[] Position { get; set; }

        public ProgressDTO(bool[] unlockedRooms, bool[] papersCollectedInRoom, Vector3 lastPlayerPos)
        {

            UnlockedRooms = unlockedRooms;
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
