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

        int maxRangeX = (mazeSize.x /2) + 1;
        int maxRangeY = (mazeSize.y / 2) + 1;


        int dimensionX = Random.Range(5, maxRangeX);
        int dimensionY = Random.Range(5, maxRangeY);


        MazeGen newMaze = Instantiate(genPrefab, mazepos, Quaternion.identity, transform);
        newMaze.setCenter(mazepos);
        newMaze.setMazeSize(dimensionX, dimensionY);
        int mazeCount = 1;
        mazes.Add(newMaze);
        ocupied += dimensionX * dimensionY;

        bool reset=false;
        while (mazeSize.x*mazeSize.y>ocupied)
        {

            //Debug.Log("generam maze nr " + mazeCount);

            dimensionX = Random.Range(4, maxRangeX);
            dimensionY = Random.Range(4, maxRangeY);


            ocupied += dimensionX * dimensionY;
            Vector3 v3 = new Vector3();
            if(reset)
            {
                v3 = mazepos;
                reset = false;
            }
            else
            {
                v3 = mazes[mazeCount - 1].getCenter() + new Vector3(mazes[mazeCount - 1].getMazeSize().x / 2f + dimensionX / 2f, 0, 0);
            }

            MazeGen newMaze2 = Instantiate(genPrefab, v3, Quaternion.identity, transform);
            newMaze2.setCenter(v3);
            newMaze2.setMazeSize(dimensionX, dimensionY);
            mazes.Add(newMaze2);

            if(newMaze2.transform.position.x+dimensionX>mazeSize.x)
            {
                mazepos = mazepos + new Vector3(0, 0, maxRangeY-1);
                reset = true;
            }

            mazeCount++;


        }

        foreach (MazeGen m in mazes)
        {
            m.Generate(Instant);
        }


    }


    void generateLines()
    {

        Vector3 mazepos = new Vector3(0, 0, 0) + transform.GetComponentInParent<Transform>().position;
        Vector3 maxX = mazepos;
        int ocupied = 0;

        List<MazeGen> mazes = new List<MazeGen>();

        int maxRangeX = (mazeSize.x / 3) + 1;
        int maxRangeY = (mazeSize.y / 3) + 1;


        int dimensionX = Random.Range(5, maxRangeX);
        int dimensionY = Random.Range(5, maxRangeY);


        MazeGen newMaze = Instantiate(genPrefab, mazepos, Quaternion.identity, transform);
        newMaze.setCenter(mazepos);
        newMaze.setMazeSize(dimensionX, dimensionY);
        int mazeCount = 1;
        mazes.Add(newMaze);
        ocupied += dimensionX * dimensionY;

        bool reset = false;
        while (mazeSize.x * mazeSize.y > ocupied)
        {

            //Debug.Log("generam maze nr " + mazeCount);

            dimensionX = Random.Range(4, maxRangeX);
            dimensionY = Random.Range(4, maxRangeY);


            ocupied += dimensionX * dimensionY;
            Vector3 v3 = new Vector3();
            if (reset)
            {
                v3 = mazepos;
                reset = false;
            }
            else
            {
                v3 = mazes[mazeCount - 1].getCenter() + new Vector3(mazes[mazeCount - 1].getMazeSize().x / 2f + dimensionX / 2f, 0, 0);
            }

            MazeGen newMaze2 = Instantiate(genPrefab, v3, Quaternion.identity, transform);
            newMaze2.setCenter(v3);
            newMaze2.setMazeSize(dimensionX, dimensionY);
            mazes.Add(newMaze2);

            if (newMaze2.transform.position.x + dimensionX > mazeSize.x)
            {
                mazepos = mazepos + new Vector3(0, 0, maxRangeY - 1);
                reset = true;
            }

            mazeCount++;


        }

        foreach (MazeGen m in mazes)
        {
            m.Generate(Instant);
        }
    }

}
