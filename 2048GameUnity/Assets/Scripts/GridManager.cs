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
    public float countPlayerCollision;
    public int threshold;
    private List<Vector3> SpawnPoints = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        threshold = 10000000;
        countPlayerCollision = 0;
        foreach (Transform spawn in Spawners.GetComponentInChildren<Transform>())
        {
            SpawnPoints.Add(spawn.position);
        }
        foreach (Transform child in Spawners.GetComponentInChildren<Transform>())
        {
            GameObject.Destroy(child.gameObject);
        }
        startingBlocksNum = 2;
        List<int> blockSpawnAlreadyUsed = new List<int>();
        bool shouldPlace = true;
        int num = Random.Range(0, SpawnPoints.Count - 1);
        for (int i = 0; i < startingBlocksNum; i++)
        {
            blockSpawnAlreadyUsed.Add(num);
            if (shouldPlace)
            {
                Instantiate(prefab, SpawnPoints[num], Quaternion.identity);
                Debug.Log(num);
            }
            num = Random.Range(0, SpawnPoints.Count - 1);
            for (int j = 0; j < blockSpawnAlreadyUsed.Count; j++)
            {
                if (num == blockSpawnAlreadyUsed[j])
                {
                    shouldPlace = false;
                    break;
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        countPlayerCollision += (1 * Time.deltaTime);
        if (countPlayerCollision > (threshold * Time.deltaTime))
        {
            countPlayerCollision = 0;

            SpawnAtARandomSpawnPoint();
        }
    }
    public void SpawnAtARandomSpawnPoint()
    {
        int num = Random.Range(0, SpawnPoints.Count - 1);
        Instantiate(prefab, SpawnPoints[num], Quaternion.identity);
        Debug.Log(num);
    }

}
