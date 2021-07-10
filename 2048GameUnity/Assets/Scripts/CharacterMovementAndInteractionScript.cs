using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementAndInteractionScript : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed = 5f;
   

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        moveWithInput();
    }

    public void moveWithInput()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
    }

}
