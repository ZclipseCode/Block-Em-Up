using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewBlock : MonoBehaviour
{
    Block actualBlock;

    void Start()
    {
        actualBlock = GetComponent<Block>();
    }

    void Update()
    {
        gameObject.transform.position = actualBlock.transform.position;
    }
}
