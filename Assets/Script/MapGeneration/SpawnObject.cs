using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] tiles;
    private int rand;
    private void Awake()
    {
        rand = Random.Range(0, tiles.Length);
    }
    private void Start()
    {
        Instantiate(tiles[rand], transform.position, Quaternion.identity);
    }
}
