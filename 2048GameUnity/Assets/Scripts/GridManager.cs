using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public float x_start;
    public float z_start;
    public int rlength;
    public int clength;
    public float x_space;
    public float z_space;
    public int startingBlocksNum;
    public GameObject prefab;
    public GameObject Spawners;
    private List<Transform> SpawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform spawn in Spawners.GetComponentInChildren<Transform>())
        {
            for(int i = 0; i <SpawnPoints.Count; i ++)
            {
                SpawnPoints[i] = spawn;
            }

        }
        startingBlocksNum = 2;
        List<int> blockSpawnAlreadyUsed = new List<int>();
        for(int i = 0; i <startingBlocksNum; i++)
        {
            int num = Random.Range(0, SpawnPoints.Count);
            blockSpawnAlreadyUsed.Add(num);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnAtARandomSpawnPoint()
    {

    }
}
