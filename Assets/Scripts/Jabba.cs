using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jabba : MonoBehaviour
{
    public Transform toFollow;
    private bool follow;
    [SerializeField] private float dist;
    [SerializeField] private float speed;

    [SerializeField] private GameObject blockers;
    
    // Start is called before the first frame update
    void Start()
    {
        follow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
        {
            float currentDist = Vector2.Distance(transform.position, toFollow.position);
            if (currentDist > dist)
            {
                transform.position = Vector2.MoveTowards(transform.position, toFollow.position, Time.deltaTime * speed);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lettuce"))
        {
            {
                follow = true;
                blockers.SetActive(false);
            }
        }
    }
}
