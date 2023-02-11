using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] float scaleFactor;
    [SerializeField] float fallSpeed;
    float elapsedTime;

    bool cwValid = true;
    bool ccwValid = true;
    SpriteRenderer grid;
    [SerializeField] SpriteRenderer blockBounds;

    [Header("Specific Blocks")]
    [SerializeField] bool isJ;

    void Start()
    {
        grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > fallSpeed)
        {
            gameObject.transform.position -= new Vector3(0, scaleFactor, 0);

            elapsedTime = 0;
        }

        if (transform.position.x + blockBounds.bounds.size.x > grid.bounds.size.x / 2)
        {
            cwValid = false;
        }
        else
        {
            cwValid = true;
        }

        if (transform.position.x - blockBounds.bounds.size.x / 2 < -grid.bounds.size.x / 2)
        {
            ccwValid = false;
        }
        else
        {
            ccwValid = true;
        }
    }

    public void RotateClockwise()
    {
        if (cwValid)
        {
            transform.rotation *= Quaternion.Euler(0, 0, -90);
        }
        else
        {
            if (isJ)
            {
                transform.position = new Vector2(transform.position.x - (transform.localScale.x * 2), transform.position.y);

                cwValid = true;

                RotateClockwise();
            }
            else
            {
                transform.position = new Vector2(transform.position.x - transform.localScale.x, transform.position.y);

                cwValid = true;

                RotateClockwise();
            }
        }
    }

    public void RotateCounterClockwise()
    {
        if (ccwValid)
        {
            transform.rotation *= Quaternion.Euler(0, 0, 90);
        }
        else
        {
            transform.position = new Vector2(transform.position.x + transform.localScale.x, transform.position.y);

            ccwValid = true;

            RotateCounterClockwise();
        }
    }
}
