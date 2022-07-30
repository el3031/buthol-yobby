using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private string nextScene;
    [SerializeField] private Transform[] characters;

    private Collider2D collider2d;

    void Start()
    {
        collider2d = GetComponent<Collider2D>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter");
        foreach (Transform c in characters)
        {
            if (c.position.x < transform.position.x)
            {
                break;
            }
        }
        SceneManager.LoadScene(nextScene);
    }
}
