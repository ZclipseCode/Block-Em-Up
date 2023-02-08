using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//***
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    float horizontalMovement;
    GameObject block;
    bool movePressed;
    bool clockwiseReady;
    bool counterClockwiseReady;

    bool inRightBoundary = false;
    bool inLeftBoundary = false;

    void Start()
    {

    }

    void Update()
    {
        block = GameObject.FindGameObjectWithTag("Block");

        if (block != null)
        {
            if (movePressed && horizontalMovement == 1 && !inRightBoundary)
            {
                block.transform.position = new Vector2(block.transform.position.x + block.transform.localScale.x, block.transform.position.y);
                movePressed = false;
            }
            else if (movePressed && horizontalMovement == -1 && !inLeftBoundary)
            {
                block.transform.position = new Vector2(block.transform.position.x - block.transform.localScale.x, block.transform.position.y);
                movePressed = false;
            }
            else if (horizontalMovement == 0)
            {
                movePressed = true;
            }

            if (clockwiseReady)
            {
                block.GetComponent<Block>().RotateClockwise();
                clockwiseReady = false;
            }
            if (counterClockwiseReady)
            {
                block.GetComponent<Block>().RotateCounterClockwise();
                counterClockwiseReady = false;
            }
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

    public void RightBoundary()
    {
        inRightBoundary = !inRightBoundary;
    }

    public void LeftBoundary()
    {
        inLeftBoundary = !inLeftBoundary;
    }
}
