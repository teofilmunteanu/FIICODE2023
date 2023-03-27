using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGen : MonoBehaviour
{
    [SerializeField] MazeGen genPrefab;
    [SerializeField] Vector2Int mazeSize;
    [SerializeField] bool Instant;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 mazepos = new Vector3(0, 0, 0) + transform.GetComponentInParent<Transform>().position;
        Vector3 maxX = mazepos;
        int ocupied=0;

        List<MazeGen> mazes = new List<MazeGen>();



        int dimensionX = Random.Range(5, mazeSize.x / 3);
        int dimensionY = Random.Range(5, mazeSize.y / 3);


        MazeGen newMaze = Instantiate(genPrefab, mazepos, Quaternion.identity, transform);
        newMaze.setCenter(mazepos);
        newMaze.setMazeSize(dimensionX, dimensionY);
        int mazeCount = 1;
        mazes.Add(newMaze);
        ocupied += dimensionX * dimensionY;


        while (mazeSize.x*mazeSize.y>ocupied)
        {

            Debug.Log("generam maze nr " + mazeCount);

            dimensionX = Random.Range(4, mazeSize.x / 4);
            dimensionY = Random.Range(4, mazeSize.y / 4);


            ocupied += dimensionX * dimensionY;

            MazeGen newMaze2 = Instantiate(genPrefab, mazes[mazeCount-1].getCenter() + new Vector3(mazes[mazeCount-1].getMazeSize().x / 2f + dimensionX / 2f, 0, 0), Quaternion.identity, transform);
            newMaze2.setCenter(mazes[mazeCount - 1].getCenter() + new Vector3(mazes[mazeCount - 1].getMazeSize().x / 2f + dimensionX / 2f,0,0));
            newMaze2.setMazeSize(dimensionX, dimensionY);
            mazes.Add(newMaze2);
            mazeCount++;


        }
        

        foreach(MazeGen m in mazes)
        {
            m.Generate(Instant);
        }


    }


}
