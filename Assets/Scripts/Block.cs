using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] float scaleFactor;
    [SerializeField] float fallSpeed;
    float elapsedTime;

    void Start()
    {

    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > fallSpeed)
        {
            gameObject.transform.position -= new Vector3(0, scaleFactor, 0);

            elapsedTime = 0;
        }
    }

    public void RotateClockwise()
    {
        transform.rotation *= Quaternion.Euler(0, 0, -90);
    }

    public void RotateCounterClockwise()
    {
        transform.rotation *= Quaternion.Euler(0, 0, 90);
    }
}
