using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.GraphicsBuffer;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] PlayerMovement2Dmodified MovementScript;
    // public Transform Player;
    List<Vector2> position;
    bool executa = false;
    public GameObject prefab;
    int i = 0;
    void Start()
    {
        position = new List<Vector2>();
        position.Add(transform.position);
        for (float j = transform.position.x; j < MovementScript.rb.position.x; j += 0.2f)
        {
            position.Add(new Vector2(j,transform.position.y));
        }
    }

    private void FixedUpdate()
    {
       
        if (MovementScript.movement != Vector2.zero)
        {
            Debug.Log(position.Count);
            position.Add(MovementScript.rb.position);
        }
        transform.right = new Vector3(position[0].x, position[0].y, 0) - transform.position;
        if (position.Count > 50 && !executa)
        {
            executa = true;
            InvokeRepeating("Following", 0.5f, 1f * Time.deltaTime);
        }
    }

    void Following()
    {
        if (position.Count > 1)
        {
            transform.position = position[0];
            GameObject newObject;
            i++;
            if (i % 3== 0)
            { 
                newObject = Instantiate(prefab, position[1], Quaternion.identity);
                i = i / 10;
            }
            position.RemoveAt(0);

            
        }

    }


}


