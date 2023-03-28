using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{
    [SerializeField] MazeNode nodePrefab;
    [SerializeField] Vector2Int mazeSize;
    [SerializeField] bool Instant;


    private Vector3 center;
    private bool DeadEndFound=false;

/*    private void Start()
    {
        if (Instant)
        {
            GenerateMazeInstant(mazeSize);
        }
        else
        {
            StartCoroutine(GenerateMaze(mazeSize));

        }
    }
*/
    public void Generate(bool instant)
    {
        if (Instant)
        {
            GenerateMazeInstant(mazeSize);
        }
        else
        {
            StartCoroutine(GenerateMaze(mazeSize));

        }
    }

    void GenerateMazeInstant(Vector2Int size)
    {
        List<MazeNode> nodes = new List<MazeNode>();

        // Create nodes
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3 nodePos = new Vector3(x - (size.x / 2f), y - (size.y / 2f),0)+transform.GetComponentInParent<Transform>().position;
                MazeNode newNode = Instantiate(nodePrefab, nodePos, Quaternion.identity, transform);
                nodes.Add(newNode);
            }
        }

        List<MazeNode> currentPath = new List<MazeNode>();
        List<MazeNode> completedNodes = new List<MazeNode>();

        List<MazeNode> deadEnds = new List<MazeNode>();

        // Choose starting node
        currentPath.Add(nodes[Random.Range(0, nodes.Count)]);
        //currentPath[0].SetState(NodeState.Current);

        while (completedNodes.Count < nodes.Count)
        {
            // Check nodes next to the current node
            List<int> possibleNextNodes = new List<int>();
            List<int> possibleDirections = new List<int>();

            int currentNodeIndex = nodes.IndexOf(currentPath[currentPath.Count - 1]);
            int currentNodeX = currentNodeIndex / size.y;
            int currentNodeY = currentNodeIndex % size.y;

            if (currentNodeX < size.x - 1)
            {
                // Check node to the right of the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex + size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + size.y]))
                {
                    possibleDirections.Add(1);
                    possibleNextNodes.Add(currentNodeIndex + size.y);
                }
            }

            if (currentNodeX > 0)
            {
                // Check node to the left of the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex - size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - size.y]))
                {
                    possibleDirections.Add(2);
                    possibleNextNodes.Add(currentNodeIndex - size.y);
                }
            }

            if (currentNodeY < size.y - 1)
            {
                // Check node above the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex + 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + 1]))
                {
                    possibleDirections.Add(3);
                    possibleNextNodes.Add(currentNodeIndex + 1);
                }
            }

            if (currentNodeY > 0)
            {
                // Check node below the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex - 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - 1]))
                {
                    possibleDirections.Add(4);
                    possibleNextNodes.Add(currentNodeIndex - 1);
                }
            }

            // Choose next node
            if (possibleDirections.Count > 0)
            {
                int chosenDirection = Random.Range(0, possibleDirections.Count);
                MazeNode chosenNode = nodes[possibleNextNodes[chosenDirection]];

                switch (possibleDirections[chosenDirection])
                {
                    case 1:
                        chosenNode.RemoveWall(1);
                        currentPath[currentPath.Count - 1].RemoveWall(0);
                        break;
                    case 2:
                        chosenNode.RemoveWall(0);
                        currentPath[currentPath.Count - 1].RemoveWall(1);
                        break;
                    case 3:
                        chosenNode.RemoveWall(3);
                        currentPath[currentPath.Count - 1].RemoveWall(2);
                        break;
                    case 4:
                        chosenNode.RemoveWall(2);
                        currentPath[currentPath.Count - 1].RemoveWall(3);
                        break;
                }

                currentPath.Add(chosenNode);
                //chosenNode.SetState(NodeState.Current);
                DeadEndFound = false;
            }
            else
            {
                completedNodes.Add(currentPath[currentPath.Count - 1]);

                if(!DeadEndFound)
                {
                    deadEnds.Add(currentPath[currentPath.Count - 1]);
                    DeadEndFound = true;
                }

                    //currentPath[currentPath.Count - 1].SetState(NodeState.Completed);
                
                
                currentPath.RemoveAt(currentPath.Count - 1);

            }
        }

        foreach (MazeNode n in deadEnds)
        {
           // n.SetState(NodeState.DeadEnd);
        }
        int teleport=Random.Range(0, deadEnds.Count - 1);

        deadEnds[teleport].GetComponent<BoxCollider2D>().enabled = true;


    }

    IEnumerator GenerateMaze(Vector2Int size)
    {
        List<MazeNode> nodes = new List<MazeNode>();

        // Create nodes
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3 nodePos = new Vector3(x - (size.x / 2f), 0, y - (size.y / 2f)) + transform.GetComponentInParent<Transform>().position;
                MazeNode newNode = Instantiate(nodePrefab, nodePos, Quaternion.identity, transform);
                nodes.Add(newNode);

                yield return null;
            }
        }

        List<MazeNode> currentPath = new List<MazeNode>();
        List<MazeNode> completedNodes = new List<MazeNode>();

        List<MazeNode> deadEnds = new List<MazeNode>();

        // Choose starting node
        currentPath.Add(nodes[Random.Range(0, nodes.Count)]);
        //currentPath[0].SetState(NodeState.Current);

        while (completedNodes.Count < nodes.Count)
        {
            // Check nodes next to the current node
            List<int> possibleNextNodes = new List<int>();
            List<int> possibleDirections = new List<int>();

            int currentNodeIndex = nodes.IndexOf(currentPath[currentPath.Count - 1]);
            int currentNodeX = currentNodeIndex / size.y;
            int currentNodeY = currentNodeIndex % size.y;

            if (currentNodeX < size.x - 1)
            {
                // Check node to the right of the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex + size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + size.y]))
                {
                    possibleDirections.Add(1);
                    possibleNextNodes.Add(currentNodeIndex + size.y);
                }
            }
            if (currentNodeX > 0)
            {
                // Check node to the left of the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex - size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - size.y]))
                {
                    possibleDirections.Add(2);
                    possibleNextNodes.Add(currentNodeIndex - size.y);
                }
            }
            if (currentNodeY < size.y - 1)
            {
                // Check node above the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex + 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + 1]))
                {
                    possibleDirections.Add(3);
                    possibleNextNodes.Add(currentNodeIndex + 1);
                }
            }
            if (currentNodeY > 0)
            {
                // Check node below the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex - 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - 1]))
                {
                    possibleDirections.Add(4);
                    possibleNextNodes.Add(currentNodeIndex - 1);
                }
            }

            // Choose next node
            if (possibleDirections.Count > 0)
            {
                int chosenDirection = Random.Range(0, possibleDirections.Count);
                MazeNode chosenNode = nodes[possibleNextNodes[chosenDirection]];

                switch (possibleDirections[chosenDirection])
                {
                    case 1:
                        chosenNode.RemoveWall(1);
                        currentPath[currentPath.Count - 1].RemoveWall(0);
                        break;
                    case 2:
                        chosenNode.RemoveWall(0);
                        currentPath[currentPath.Count - 1].RemoveWall(1);
                        break;
                    case 3:
                        chosenNode.RemoveWall(3);
                        currentPath[currentPath.Count - 1].RemoveWall(2);
                        break;
                    case 4:
                        chosenNode.RemoveWall(2);
                        currentPath[currentPath.Count - 1].RemoveWall(3);
                        break;
                }

                currentPath.Add(chosenNode);
                //chosenNode.SetState(NodeState.Current);
                DeadEndFound = false;
            }
            else
            {
                completedNodes.Add(currentPath[currentPath.Count - 1]);

                if (!DeadEndFound)
                {
                    deadEnds.Add(currentPath[currentPath.Count - 1]);
                    DeadEndFound = true;
                }

                //currentPath[currentPath.Count - 1].SetState(NodeState.Completed);
                
                currentPath.RemoveAt(currentPath.Count - 1);
            }

            

            yield return new WaitForSeconds(0.05f);
        }


        foreach (MazeNode n in deadEnds)
        {
            //n.SetState(NodeState.DeadEnd);
        }
    }

    public void setMazeSize(int x,int y)
    {
        mazeSize.x = x;
        mazeSize.y = y;
    }

    public Vector2Int getMazeSize()
    {
        return mazeSize;
    }

    public void setCenter(Vector3 v)
    {
        center = v;
    }

    public Vector3 getCenter()
    {
        return center;
    }



}
