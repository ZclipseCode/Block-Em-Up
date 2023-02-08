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

    Block blockScript;
    bool clockwiseReady;
    bool counterClockwiseReady;

    void Start()
    {
        blockScript = GetComponent<Block>();
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

        if (clockwiseReady)
        {
            blockScript.RotateClockwise();
            clockwiseReady = false;
        }
        if (counterClockwiseReady)
        {
            blockScript.RotateCounterClockwise();
            counterClockwiseReady = false;
        }
    }

    public void HorizontalMove(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<float>();
        movePressed = true;
    }

    public void RotateClockwise(InputAction.CallbackContext context)
    {
        clockwiseReady = context.action.triggered;
    }

    public void RotateCounterClockwise(InputAction.CallbackContext context)
    {
        counterClockwiseReady = context.action.triggered;
    }
}
