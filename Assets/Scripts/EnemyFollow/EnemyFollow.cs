using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFollow : MonoBehaviour
{
    public Transform Player;
    [SerializeField]
    float MoveSpeed = 5f;
    Vector2 pos;
    private void Start()
    {
    }
    private void Update()
    {
        Move();
    }

    public void Move()
    { 
        transform.LookAt(Player);
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }
}
