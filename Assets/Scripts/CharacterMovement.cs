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

public float myHealth;
public float myDamageDealt;
public float myDamageTaken;

 private enum State
    {
        Idle,
        Attacking,
        Dodging,
        Blocking,
        Parrying
    }

    // Start is called before the first frame update
    void Start()
    {
        
        startPosition = playerChar.transform.position;
        startRotation = playerChar.transform.rotation;

        myHealth = 100f;
        myDamageDealt = 10f;

State = State.Idle;
        // get current animation length (for later)
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
                State = State.Attacking;
            yield return new WaitForSeconds(1.2f);

            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
State = State.Idle;
            
        }
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerChar.GetComponent<Animator>().Play("Dodge Left");
                State = State.Dodging;
            yield return new WaitForSeconds(1.2f);

            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
State = State.Idle;
            
        }
            if (Input.GetKeyDown(KeyCode.Q))
            {
               
                playerChar.GetComponent<Animator>().Play("Parry");
                State = State.Parrying;
            yield return new WaitForSeconds(1.4f);

            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
State = State.Idle;
            
        }
            if (Input.GetKeyDown(KeyCode.D))
            {
                playerChar.GetComponent<Animator>().Play("Dodge Right");
                State = State.Dodging;
            yield return new WaitForSeconds(1.2f);

            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
State = State.Idle;
            
        }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerChar.GetComponent<Animator>().Play("Block");
                 State = State.Blocking;
            yield return new WaitForSeconds(0.3f);

            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
State = State.Idle;
           
        }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                playerChar.GetComponent<Animator>().Play("Left Top Down");
                State = State.Attacking;
            yield return new WaitForSeconds(2f);

            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
State = State.Idle;
            
        }
            
    }

}

