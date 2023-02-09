using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//***
using UnityEngine.InputSystem;

public class PlayerInputScript : MonoBehaviour
{
    float horizontalMovement;
    GameObject piece;
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
        piece = GameObject.FindGameObjectWithTag("Piece");

        if (piece != null)
        {
            if (movePressed && horizontalMovement == 1 && !inRightBoundary)
            {
                piece.transform.position = new Vector2(piece.transform.position.x + piece.transform.localScale.x, piece.transform.position.y);
                movePressed = false;
            }
            else if (movePressed && horizontalMovement == -1 && !inLeftBoundary)
            {
                piece.transform.position = new Vector2(piece.transform.position.x - piece.transform.localScale.x, piece.transform.position.y);
                movePressed = false;
            }
            else if (horizontalMovement == 0)
            {
                movePressed = true;
            }

            if (clockwiseReady)
            {
                piece.GetComponent<Block>().RotateClockwise();
                clockwiseReady = false;
            }
            if (counterClockwiseReady)
            {
                piece.GetComponent<Block>().RotateCounterClockwise();
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
