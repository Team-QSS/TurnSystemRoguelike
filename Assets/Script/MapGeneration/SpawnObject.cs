using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] tiles;
    private int rand;
    private Transform parent;
    private void Awake()
    {
        rand = Random.Range(0, tiles.Length);
        parent = transform.parent;
    }
    private void Start()
    {
        Instantiate(tiles[rand], transform.position, Quaternion.identity).transform.SetParent(parent);
        Destroy(this.gameObject);
    }
}
