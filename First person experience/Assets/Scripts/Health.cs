using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int hp;
    int maxHp;
    public bool respawn;
    public float respawnTime;
    bool active;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
           if (!active)
            {
              StartCoroutine(RespawnObject());
            }
            else if (!respawn)
            {
              Destroy(gameObject);
            }
        }
    }


    IEnumerator RespawnObject()
    {  
        active = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(respawnTime);

        gameObject.GetComponent<MeshRenderer>().enabled = true;
        hp = maxHp;
        active = false;
    }



}
