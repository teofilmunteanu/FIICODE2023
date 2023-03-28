using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Tilemaps;
using static UnityEngine.GraphicsBuffer;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] PlayerMovement2Dmodified MovementScript;
    [SerializeField] GameObject[] obj ;
    [SerializeField] TilemapRenderer tm;
    // public Transform Player;
    List<Vector2> position;
    bool executa = false;
    public GameObject prefab;
    int i = 0;
    private IEnumerator couritine;
    void Start()
    {
        position = new List<Vector2>();
        position.Add(transform.position);
        for (float j = transform.position.x; j < MovementScript.rb.position.x; j += 0.2f)
        {
            position.Add(new Vector2(j,transform.position.y));
        }
        couritine = Following();
    }

    private void FixedUpdate()
    {
        int j = 0;
        if (MovementScript.movement != Vector2.zero)
        {
            position.Add(MovementScript.rb.position);
        }
        transform.right = new Vector3(position[0].x, position[0].y, 0) - transform.position;
        if (position.Count > 50 && !executa)
        {
            executa = true;
            //InvokeRepeating("Following", 0.5f, 1f * Time.deltaTime);
            StartCoroutine(couritine);
        }
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i].GetComponent<PressedButton>().isPressed)
            {
                j++;
            }
        }
        if (j==5)
        {
            StopCoroutine(couritine);
            tm.enabled = false;
            foreach(var collider in tm.GetComponentsInChildren<Collider2D>())
                collider.enabled = false;
        }
    }

    IEnumerator Following()
    {
        while (true)
        {
            if (position.Count > 1)
            {
                transform.position = position[0];
                GameObject newObject;
                i++;
                if (i % 3 == 0)
                {
                    newObject = Instantiate(prefab, position[1], Quaternion.identity);
                    i = i / 3;
                }
                position.RemoveAt(0);
                //yield return new WaitForSeconds(.1f);
            }
            yield return new WaitForSeconds(0.9f * Time.fixedDeltaTime);
        }

    }
}


