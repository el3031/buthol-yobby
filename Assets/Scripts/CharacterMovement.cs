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
    }

    
}
