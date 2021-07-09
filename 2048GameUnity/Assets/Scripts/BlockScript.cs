using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    protected int value;
    // Start is called before the first frame update
    void Start()
    {
        value = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.collider.gameObject;
        if (other.tag == "Block")
        {
            if(other.GetComponent<BlockScript>().value == value)
            {
                value *= 2;
                Destroy(other); //might not work because we are destroying the copy not the actual object probs need to use 'collision.collider.gameObject'
            }
        }
    }
}
