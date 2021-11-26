using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    Animator animator;
   
    AnimatorClipInfo[] currentClipInfo;

    float currentClipLength;

    public GameObject playerChar;

    Vector3 startPosition;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = playerChar.transform.position;
        startRotation = playerChar.transform.rotation;
        // For animation length (for later)
      /*  animator = gameObject.GetComponent<Animator>();
        currentClipInfo = this.animator.GetCurrentAnimatorClipInfo(0);
       
        currentClipLength = currentClipInfo[0].clip.length;*/

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PlayAnims());
    }

    IEnumerator PlayAnims()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                playerChar.GetComponent<Animator>().Play("Right Top Down Attack");
            yield return new WaitForSeconds(1.2f);
            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
        }
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerChar.GetComponent<Animator>().Play("Dodge Left");
            yield return new WaitForSeconds(1.2f);
            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
        }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("A");
                playerChar.GetComponent<Animator>().Play("Parry");
            yield return new WaitForSeconds(1.4f);
            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
        }
            if (Input.GetKeyDown(KeyCode.D))
            {
                playerChar.GetComponent<Animator>().Play("Dodge Right");
            yield return new WaitForSeconds(1.2f);
            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
        }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerChar.GetComponent<Animator>().Play("Block");
            yield return new WaitForSeconds(0.3f);
            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
        }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                playerChar.GetComponent<Animator>().Play("Left Top Down");
            yield return new WaitForSeconds(2f);
            // playerChar.transform.position = new Vector3(initialPositionX, 0, initialPositionZ);
            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
        }
            
    }
    

}

