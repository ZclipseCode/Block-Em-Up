using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackInBounds : MonoBehaviour
{
    GameObject piece;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Piece")
        {
            piece = collision.gameObject;
            piece.transform.position = new Vector2(0, 0);
        }
    }
}
