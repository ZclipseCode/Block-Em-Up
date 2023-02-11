using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] pieces = new GameObject[7];

    void Start()
    {
        SpawnPiece();
    }

    void Update()
    {
        
    }

    public void SpawnPiece()
    {
        Instantiate(pieces[Random.Range(0, pieces.Length)], transform.position, Quaternion.identity);
    }
}
