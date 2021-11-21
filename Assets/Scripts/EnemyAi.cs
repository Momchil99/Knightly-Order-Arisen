using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public AnimationClip[] attackAnims;
    private Animator animator;
    
    public GameObject enemy;

    private float timeToAction;
    private float cooldown;

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
        attackAnims = animator.runtimeAnimatorController.animationClips;
        timeToAction = Time.time + cooldown;
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Idle:
                if(timeToAction < Time.time)
                {
                    state = State.Attacking;
                }
                break;

            case State.Attacking:
                timeToAction = Time.time + cooldown;
                var randInd = Random.Range(0, attackAnims.Length);
                var randClip = attackAnims[randInd];
                animator.Play(randClip.name);
                state = State.Idle;
                break;
        }
    }
}
