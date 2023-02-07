using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] float scaleFactor;
    public float fallSpeed;
    float elapsedTime;

    void Start()
    {
        gameObject.transform.localScale *= scaleFactor;
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
}
