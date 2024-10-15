using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{

    public int damage;
    public float shootDistance;
    public LayerMask layerMask;
    public GameObject cam;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, shootDistance, layerMask))
                {
                    hit.collider.gameObject.GetComponent<Health>().hp -= damage;
                }
            }
        }
    }
}
