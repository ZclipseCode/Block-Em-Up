using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalGridBoundaries : MonoBehaviour
{
    [SerializeField] bool isRight = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isRight && collision.gameObject.tag == "Block")
        {
            PlayerInputScript input = GameObject.FindGameObjectWithTag("Input").GetComponent<PlayerInputScript>();

            input.RightBoundary();
        }

        if (!isRight && collision.gameObject.tag == "Block")
        {
            PlayerInputScript input = GameObject.FindGameObjectWithTag("Input").GetComponent<PlayerInputScript>();

            input.LeftBoundary();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isRight && collision.gameObject.tag == "Block")
        {
            PlayerInputScript input = GameObject.FindGameObjectWithTag("Input").GetComponent<PlayerInputScript>();

            input.RightBoundary();
        }

        if (!isRight && collision.gameObject.tag == "Block")
        {
            PlayerInputScript input = GameObject.FindGameObjectWithTag("Input").GetComponent<PlayerInputScript>();

            input.LeftBoundary();
        }
    }
}
