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
        generateLines();


        

    }

    void generatesquare()
    {

        int[,] m = new int[mazeSize.x,mazeSize.y];

        for (int i = 0; i < mazeSize.x; i++)
        {
            for (int j = 0; j < mazeSize.y; j++)
            {
                m[i, j] = 0;
            }
        }

        Vector3 mazepos = new Vector3(0, 0, 0) + transform.GetComponentInParent<Transform>().position;

        List<MazeGen> mazes = new List<MazeGen>();

        int maxRangeX = (mazeSize.x / 2) + 1;
        //int maxRangeY = (mazeSize.y / 2) + 1;

        int dimensionX = Random.Range(4, maxRangeX);
        int dimensionY = 6;//Random.Range(4, maxRangeY);

        int ocupied = 0;

        MazeGen newMaze = Instantiate(genPrefab, mazepos, Quaternion.identity, transform);
        newMaze.setCenter(mazepos);
        newMaze.setMazeSize(dimensionX, dimensionY);
        int mazeCount = 1;
        mazes.Add(newMaze);
        ocupied += dimensionX * dimensionY;

        for(int i=0;i<dimensionX;i++)
        {
            for (int j = 0; j < dimensionY; j++)
            {
                m[i,j] = 1;
            }
        }

        while (mazeSize.x * mazeSize.y > ocupied)
        {


            


        }
    }

    void generateLines()
    {
        Vector3 mazepos = new Vector3(0, 0, 0) + transform.GetComponentInParent<Transform>().position;
        int ocupied = 0;

        List<MazeGen> mazes = new List<MazeGen>();

        int maxRangeX = (mazeSize.x / 2) + 1;
        //int maxRangeY = (mazeSize.y / 2) + 1;


        int dimensionX = Random.Range(4, maxRangeX);
        int dimensionY = 6;//Random.Range(5, maxRangeY);


        MazeGen newMaze = Instantiate(genPrefab, mazepos, Quaternion.identity, transform);
        newMaze.setCenter(mazepos);
        newMaze.setMazeSize(dimensionX, dimensionY);
        int mazeCount = 1;
        mazes.Add(newMaze);
        ocupied += dimensionX * dimensionY;

        bool reset = false;

        int rows = 0;
        while (rows<4 || mazeSize.x * mazeSize.y > ocupied||!reset)
        {

            //Debug.Log("generam maze nr " + mazeCount);

            dimensionX = Random.Range(4, maxRangeX);
            //dimensionY = Random.Range(4, maxRangeY);


            ocupied += dimensionX * dimensionY;
            Vector3 v3;
            if (reset)
            {
                maxRangeX = (mazeSize.x / 2) + 1;
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
                mazepos = mazepos + new Vector3(0, 0, 6);
                reset = true;
                rows++;
            }

            mazeCount++;


        }

        foreach (MazeGen m in mazes)
        {
            m.Generate(Instant);
        }

    }

}
