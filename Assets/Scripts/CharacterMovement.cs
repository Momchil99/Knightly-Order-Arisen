using System;
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

    public int dodgecounter; 

    public EnemyAi enemyAi;

  
 private enum State
    {
        Idle,
        Attacking,
        Dodging,
        Blocking,
        Parrying
    }

    private State state;

    private void Awake()
    {
        enemyAi = FindObjectOfType<EnemyAi>();
    }

 

    // Start is called before the first frame update
    void Start()
    {
        
        startPosition = playerChar.transform.position;
        startRotation = playerChar.transform.rotation;

        myHealth = 100f;

        state = State.Idle;
        // get current animation length (for later)
      /*  animator = gameObject.GetComponent<Animator>();
        currentClipInfo = this.animator.GetCurrentAnimatorClipInfo(0);
       
        currentClipLength = currentClipInfo[0].clip.length;*/

    }

    // Update is called once per frame
    void Update()
    {
        myDamageDealt = enemyAi.enemyDamageTaken;
        StartCoroutine(PlayAnims());
    }

    IEnumerator PlayAnims()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) )
            {
                playerChar.GetComponent<Animator>().Play("Right Top Down Attack");
                state = State.Attacking;
            yield return new WaitForSeconds(1.2f);

            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
state = State.Idle;
            
        }
            if (Input.GetKeyDown(KeyCode.Q))
            {
               
                playerChar.GetComponent<Animator>().Play("Parry");
                state = State.Parrying;
            yield return new WaitForSeconds(1.4f);

            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
state = State.Idle;
            
        }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerChar.GetComponent<Animator>().Play("Block");
                 state = State.Blocking;
            yield return new WaitForSeconds(0.3f);

            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
state = State.Idle;
           
        }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
            transform.rotation = Quaternion.Euler(new Vector3(0,-183,0));
            playerChar.GetComponent<Animator>().Play("Spinning Attack");
                state = State.Attacking;
            yield return new WaitForSeconds(0.5f);

            playerChar.transform.position = startPosition;
            playerChar.transform.rotation = startRotation;
state = State.Idle;
            
        }
            
    }

    public void DodgeLeft()
    {
        playerChar.GetComponent<Animator>().Play("Dodge Left");
        state = State.Dodging;
        playerChar.transform.position = startPosition;
        playerChar.transform.rotation = startRotation;
        state = State.Idle;
    } 

    public void DodgeRight()
    {
        playerChar.GetComponent<Animator>().Play("Dodge Right");
        state = State.Dodging;
        playerChar.transform.position = startPosition;
        playerChar.transform.rotation = startRotation;
        state = State.Idle;
    }

    void noDamage()
    {
        dodgecounter++;
        Debug.Log(dodgecounter);
        enemyAi.enemyDamageDealt = 0;
    }

    void normalDamage()
    {
        enemyAi.enemyDamageDealt = 20; 
    }

}

