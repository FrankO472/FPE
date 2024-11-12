using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPos : MonoBehaviour
{
    
    void Awake()
    {
        if(GameObject.Find("Player").GetComponent<PlayerController>().spawnPoint == gameObject.name)
        {
            StartCoroutine(GameObject.Find("Player").GetComponent<PlayerController>().ResetPos());
        }
    }
}
