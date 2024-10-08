using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool isOn;


    public float moveSpeed;
    public Transform bridge;
    public Transform pointA;
    public Transform pointB;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Animator>().SetBool("leverOn", isOn);

        if (isOn)
        {
            bridge.position = Vector3.Lerp(bridge.position, pointA.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            bridge.position = Vector3.Lerp(bridge.position, pointB.position, moveSpeed * Time.deltaTime);
        }
    }
}
