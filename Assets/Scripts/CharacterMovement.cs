using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject playerChar;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("mouse");
            playerChar.GetComponent<Animator>().Play("Right Top Down Attack");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");
            playerChar.GetComponent<Animator>().Play("Block");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            playerChar.GetComponent<Animator>().Play("Dodge Left");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("A");
            playerChar.GetComponent<Animator>().Play("Dodge Right");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("A");
            playerChar.GetComponent<Animator>().Play("Parry");
        }
    }
}

