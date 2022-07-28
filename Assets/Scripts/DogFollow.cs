using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogFollow : MonoBehaviour
{
    public Transform entrance;
    public Transform bone;

    private Collider2D collider2d;
    
    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        StartCoroutine(MoveToBone());
    }

    public IEnumerator MoveToBone()
    {
        collider2d.enabled = false;

        float time = 0f;
        float timer = 3f;
        while (time < timer)
        {
            time += Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, bone.position, Time.deltaTime);
            yield return null;
        }

        time = 0f;
        float waitTimer = 5f;
        while (time < waitTimer)
        {
            time += Time.deltaTime;
            yield return null;
        }

        time = 0f;
        while (time < timer)
        {
            time += Time.deltaTime;
            transform.position = Vector2.Lerp(transform.position, entrance.position, Time.deltaTime);
            yield return null;
        }

        collider2d.enabled = true;
    }
}
