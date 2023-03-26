using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] PlayerMovement2Dmodified MovementScript;
    // public Transform Player;
    List<Vector2> position;
    bool executa = false;

    void Start()
    {
        position = new List<Vector2>();
    }

    private void Update()
    {
        if (MovementScript.movement != Vector2.zero)
        {
            position.Add(MovementScript.rb.position);
        }

        if (position.Count > 500 && !executa)
        {
            executa = true;
            InvokeRepeating("Following", 0.0f, 0.001f);
        }
    }

    void Following()
    {
        if (position.Count > 0)
        {
            transform.position = position[0];
            position.RemoveAt(0);
        }

    }
}


