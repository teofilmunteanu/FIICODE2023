using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFollow : MonoBehaviour
{

    private int snakeBodySize;
    public Transform Player;
    [SerializeField]
    float MoveSpeed = 5f;
    private void Start()
    {
    }
    private void Update()
    {
        Move();
    }

    public void Move()
    { 
    }
}
