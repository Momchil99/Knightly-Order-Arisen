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

    private enum State
    {
        Idle,
        Attacking,
        Vulnerable
    }

    private State state;

    private void Awake()
    {
        cooldown = 2f;
        animator = GetComponent<Animator>();
        timeToAction = Time.time + cooldown;
        state = State.Idle;

        triggerSelector[0] = "JumpAtk";
        triggerSelector[1] = "Punch";
        triggerSelector[2] = "Swipe";

        startPosition = enemy.transform.position;
        startRotation = enemy.transform.rotation;

enemyDamageDealt = 20f;
enemyHealth = 100f;
    }

    // Update is called once per frame
    void Update()
    {


        switch (state)
        {
            case State.Idle:
                if (timeToAction < Time.time)
                {
                    state = State.Attacking;
                }
                break;

            case State.Attacking:
                timeToAction = Time.time + cooldown;
                StartCoroutine(PlayAttackAnim());
                state = State.Idle; 
                break;
        }
    }

   IEnumerator PlayAttackAnim()
    {
        int randInd = Random.Range(0, triggerSelector.Length);
        animator.SetTrigger(triggerSelector[randInd]);
        if (randInd == 0)
        {
            cooldown = 11;
        }
        if (randInd == 1)
        {
            cooldown = 4;
        }
        if (randInd == 2)
        {
            cooldown = 6;
        }
        yield return new WaitForSeconds(triggerSelector.Length);
        enemy.transform.position = startPosition;
        enemy.transform.rotation = startRotation;
    }
    

   
}
