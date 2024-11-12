using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DND : MonoBehaviour
{
    
    public static GameObject dndObject;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (dndObject == null)
        {
            dndObject = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
            
        }
    }

   
}
