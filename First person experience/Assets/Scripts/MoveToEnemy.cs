using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToEnemy : MonoBehaviour
{
    public float damageAmount, attackDelay, attackRate, attackDistance, health;

    GameObject playerObject;

    NavMeshAgent navAgent;
    public Transform bulletPos;
    public GameObject bullet; 

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Time.time > attackDelay)
        {
            if(Vector3.Distance(playerObject.transform.position, transform.position) <= attackDistance)
            {
             Attack();
            }
        }
    }

    void Move()
    {
        navAgent.destination = playerObject.transform.position;
    }

    void Attack()
    {
         playerObject.GetComponent<PlayerHealth>().health -= damageAmount;
         attackDelay = Time.time + attackRate;
        //Instantiate (bullet, bulletPos.position, transform.rotation);
    }


}
