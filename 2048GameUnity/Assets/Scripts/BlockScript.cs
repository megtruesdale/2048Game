using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockScript : MonoBehaviour
{
    public int value;
    private GameObject holderOfText;
    public GameObject spawner;
    private Text[] labels;
    public int fSize;
    public float offset;
    Rigidbody rb;
    GameObject spawnerchecker;

    // Start is called before the first frame update
    void Start()
    {
        offset = 2.0f;
        value = 2;
        labels = GetComponentsInChildren<Text>();
        fSize = 45;
        Vector3 position = GetComponent<Transform>().position;
        rb = GetComponent<Rigidbody>();
        spawner = GameObject.FindGameObjectWithTag("Respawn");
        spawnerchecker = GameObject.FindGameObjectWithTag("SpawnChecker");
        setLabel();
    
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().material.color = spawnerchecker.GetComponent<SpawnerChecker>().Colors[(int)Mathf.Log(value, 2)];
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.collider.gameObject;
        if (other.tag == "Block")
        {

            if (other.GetComponent<BlockScript>().value == value)
            {
                value *= 2;
                Destroy(other); //might not work because we are destroying the copy not the actual object probs need to use 'collision.collider.gameObject'
                setLabel();
                if (spawner.GetComponent<GridManager>())
                {
                    spawner.GetComponent<GridManager>().SpawnAtARandomSpawnPoint();
                    if(Mathf.Log(value, 2) == 1)
                    {
                        spawner.GetComponent<GridManager>().SpawnAtARandomSpawnPoint();
                    }
                }
            }
        }
        if (other.tag == "Gound")
        {
            value *= 2;
            Destroy(other); //might not work because we are destroying the copy not the actual object probs need to use 'collision.collider.gameObject'
            setLabel();
        }
    }

    void setLabel()
    {
        foreach (Text t in labels)
        {
            t.text = value.ToString();
            t.alignment = TextAnchor.UpperLeft;
            t.fontSize = fSize;
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<CharacterMovementAndInteractionScript>())
        {
            rb.constraints = RigidbodyConstraints.None;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<CharacterMovementAndInteractionScript>())
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
        }
    }
}
