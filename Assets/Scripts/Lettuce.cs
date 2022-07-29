using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lettuce : MonoBehaviour
{
    public Transform toFollow;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jabba"))
        {
            {
                Debug.Log("jabba eat");
            }
        }
    }
}
