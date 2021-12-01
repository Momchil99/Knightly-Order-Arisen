using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
  
    private Animator animator;

    //private int[] triggerSelector;
    private string[] triggerSelector = new string[3];
    
    public GameObject enemy;

    private float timeToAction;
    private float cooldown;

    Vector3 startPosition;
    private Quaternion startRotation;

    public float enemyHealth;
public float enemyDamageDealt;
public float enemyDamageTaken;

    public CharacterMovement characterMovement;

    public enum State
    {
        Idle,
        Attacking,
        Vulnerable
    }

    public State state;

    private void Awake()
    {
        cooldown = 2f;
        animator = GetComponent<Animator>();
        timeToAction = Time.time + cooldown;
        state = State.Idle;

       characterMovement = FindObjectOfType<CharacterMovement>();
        
        triggerSelector[0] = "Punch";
        triggerSelector[1] = "Swipe";

        startPosition = enemy.transform.position;
        startRotation = enemy.transform.rotation;

enemyDamageDealt = 20f;
enemyHealth = 100f;
    }

    // Update is called once per frame
    void Update()
    {
      
  

        if (characterMovement.dodgecounter >= 4)
            state = State.Vulnerable;


        switch (state)
        {
            case State.Idle:
                enemy.GetComponent<Animator>().Play("Roaring Idle");
                enemyDamageTaken = 2f;
                

                if (timeToAction < Time.time)
                {
                    state = State.Attacking;
                }
                break;

            case State.Attacking:
                Debug.Log(state.ToString());
                timeToAction = Time.time + cooldown;
// detection is difficult as state only stays changed for 1 frame (rly fkn quick)
                enemyDamageTaken = 2f;
                
                StartCoroutine(PlayAttackAnim());
                state = State.Idle; 
                break;

            case State.Vulnerable:
                StartCoroutine(playVulnerable());
               
                break;
                
        }

     
            
    }

   IEnumerator PlayAttackAnim()
    {
        int randInd = Random.Range(0, triggerSelector.Length);
        animator.SetTrigger(triggerSelector[randInd]);
        if (randInd == 0)
        {
            cooldown = 4;
        }
        if (randInd == 1)
        {
            cooldown = 6;
        }
       
        yield return new WaitForSeconds(triggerSelector.Length);
        enemy.transform.position = startPosition;
        enemy.transform.rotation = startRotation;
    }
    
    IEnumerator playVulnerable()
    {
        Debug.Log(state.ToString());
        enemy.GetComponent<Animator>().Play("Mutant Vulnerable");
        enemyDamageTaken = 10f;
        yield return new WaitForSeconds(10);
        state = State.Idle;
        characterMovement.dodgecounter = 0;
       
    }
   
}
