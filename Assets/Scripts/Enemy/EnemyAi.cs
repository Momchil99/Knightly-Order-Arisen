using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
  
    private Animator animator;

    public string[] triggerSelector = new string[3];
    
    public GameObject enemy;

    Vector3 startPosition;
    private Quaternion startRotation;

    private float timeToAction;
    private float cooldown;

    public float enemyHealth;
    public float enemyDamageDealt;
    public float enemyDamageTaken;
    public float waitForAnim;

    public int attackMode;

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
                enemy.GetComponent<Animator>().Play("idle");
                enemyDamageTaken = 2f;
                if (timeToAction < Time.time)
                {
                    state = State.Attacking;
                }
                break;

            case State.Attacking:
                timeToAction = Time.time + cooldown;
                enemyDamageTaken = 2f;
                StartCoroutine(PlayAttackAnim());
                break;

            case State.Vulnerable:
                StartCoroutine(playVulnerable());
                break;
        }    
    }

   IEnumerator PlayAttackAnim()
    {
        state = State.Attacking;

        int randInd = Random.Range(0, triggerSelector.Length);
        animator.SetTrigger(triggerSelector[randInd]);
        if (randInd == 0)
        {
            cooldown = 4;
            waitForAnim = 6f;
        }
        if (randInd == 1)
        {
            cooldown = 6;
            waitForAnim = 2f;
        }

        yield return new WaitForSeconds(waitForAnim);

        state = State.Idle;

        enemy.transform.position = startPosition;
        enemy.transform.rotation = startRotation;
       
    }
    
    IEnumerator playVulnerable()
    {
        Debug.Log(state.ToString());
        enemy.GetComponent<Animator>().Play("Vulnerable");
        enemyDamageTaken = 10f;
        yield return new WaitForSeconds(6);
        state = State.Idle;
        characterMovement.dodgecounter = 0;
       
    }
   
}
