using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerChecker : MonoBehaviour
{
    GameObject [] BlocksInScene;
    public int highestNum;
    public List<Color> Colors = new List<Color>();
    // Start is called before the first frame update
    void Start()
    {
        Colors.Add(Color.white);
        highestNum = 2;
        CheckForBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        colorSetter();
    }
    public void checkingMax()
    {
        foreach(GameObject b in BlocksInScene)
        {
            if (b.GetComponent<BlockScript>().value > highestNum)
            {
                highestNum = b.GetComponent<BlockScript>().value;
            }
        }
    }
    public void colorSetter()
    {

        if ((Colors.Count) < Mathf.Log(highestNum, 2));
        {
            Colors.Add(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
            Debug.Log("Colors num" + Colors.Count);
        }
    }

    public void CheckForBlocks()
    {
        BlocksInScene = GameObject.FindGameObjectsWithTag("Block");
    }
}
