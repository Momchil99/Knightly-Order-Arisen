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
            playerChar.GetComponent<Animator>().Play("Right Top Down Attack");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerChar.GetComponent<Animator>().Play("Shield");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerChar.GetComponent<Animator>().Play("Dodge Left");
        }
    }
}

