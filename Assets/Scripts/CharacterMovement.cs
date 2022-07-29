using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private Collider2D collider2d;
    private Rigidbody2D rb;
    private Vector2 moveVector;

    [SerializeField] private float force;
    [SerializeField] private float _maxHorizontalSpeed;

    [SerializeField] private Collider2D bone1;
    [SerializeField] private Collider2D bone2;
    private bool canThrow;

    [SerializeField] private Collider2D[] interactables;

    
    // Start is called before the first frame update
    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Sign(rb.velocity.x) != Mathf.Sign(moveVector.x) ||
            Mathf.Abs(rb.velocity.x) < _maxHorizontalSpeed)
        {            
            rb.AddForce(force * moveVector);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.performed ? context.ReadValue<Vector2>() : Vector2.zero;
        Debug.Log(gameObject.name + " moved " + moveVector);
        canThrow = true;
    }

    public void OnBone(InputAction.CallbackContext context)
    {
        Debug.Log("press bone");
        Collider2D touching = null;
        foreach (Collider2D c in interactables)
        {
            touching = collider2d.IsTouching(c) ? c : touching;
        }
        if (touching != null)
        {
            touching.transform.parent = this.transform;
            canThrow = false;
        }
        else if (transform.childCount > 0 && canThrow)
        {
            Debug.Log("more than 1 child and canThrow");
            Transform interactable = transform.GetChild(0);
            interactable.GetComponent<Projectile>().enabled = true;
            /*
            if (interactable.CompareTag("Bone"))
            {
                interactable.GetComponent<Projectile>().enabled = true;
            }
            else if (interactable.CompareTag("Lettuce"))
            {
                interactable.parent = null;
                Lettuce l = interactable.GetComponent<Lettuce>();
                l.enabled = true;
                l.toFollow = this.transform;
            }
            */
        }
        else
        {
            Debug.Log(transform.childCount + ", canThrow: " + canThrow);
        }
        
        /*
        bool touch1 = collider2d.IsTouching(bone1);
        bool touch2 = collider2d.IsTouching(bone2);

        if (touch1 || touch2)
        {
            Collider2D bone = touch1 ? bone1 : bone2;
            
            bone.transform.parent = this.transform;
            Debug.Log("pick up bone");
            canThrow = false;
        }
        else if (transform.childCount > 0 && transform.GetChild(0).CompareTag("Bone") && canThrow)
        {
            Transform bone = transform.GetChild(0);
            bone.GetComponent<Projectile>().enabled = true;
        }
        */
    }

    
}
