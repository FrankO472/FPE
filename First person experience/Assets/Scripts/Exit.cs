using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public string levelName;
    public string spawnPoint;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().spawnPoint = spawnPoint;
            StartCoroutine(other.gameObject.GetComponent<PlayerController>().LoadNewScene(levelName));
        }
    }
}
