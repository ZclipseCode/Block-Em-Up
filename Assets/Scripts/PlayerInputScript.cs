using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//***
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    float horizontalMovement;
    [SerializeField] Transform block;
    bool movePressed;

    void Start()
    {
        
    }

    void Update()
    {
        if (movePressed && horizontalMovement == 1)
        {
            transform.position = new Vector2(transform.position.x + block.transform.localScale.x, transform.position.y);
            movePressed = false;
        }
        else if (movePressed && horizontalMovement == -1)
        {
            transform.position = new Vector2(transform.position.x - block.transform.localScale.x, transform.position.y);
            movePressed = false;
        }
        else if (horizontalMovement == 0)
        {
            movePressed = true;
        }
    }

    public void HorizontalMove(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<float>();
        movePressed = true;
    }
}
