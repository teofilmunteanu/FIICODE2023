using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
            Player.transform.position = teleportTarget.transform.position + new Vector3 (0,1,0);
        
    }
}
