using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] GameObject tile;
    [SerializeField] float scaleFactor;
    [SerializeField] int rows;
    [SerializeField] int columns;

    void Start()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                //GameObject newTile = Instantiate(tile, new Vector2((gameObject.transform.localPosition.x + i) * scaleFactor, (gameObject.transform.localPosition.y + j) * scaleFactor), Quaternion.identity);
                GameObject newTile = Instantiate(tile, gameObject.transform.localPosition + new Vector3(i * scaleFactor,  j * scaleFactor, 0), Quaternion.identity);
                newTile.transform.localScale = new Vector2(newTile.transform.localScale.x * scaleFactor, newTile.transform.localScale.y * scaleFactor);
            }
        }
    }

    void Update()
    {
        
    }
}
