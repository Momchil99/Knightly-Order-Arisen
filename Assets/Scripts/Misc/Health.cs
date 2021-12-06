using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public float health = 100f;
    

    private CharacterMovement animationScript;
    private EnemyAi enemyAI;

    private bool characterDied;

    public bool isPlayer;

    public Slider slider;

    public HealthBar healthBar;

    private void Awake()
    {
        animationScript = GetComponent<CharacterMovement>();
        enemyAI = GetComponent<EnemyAi>();
     
    }
    public void ApplyDamage(float damage, bool takehit)
    {
        if (characterDied)
            return;

        health -= damage;
       
        Debug.Log(health);

        if (health <= 0f)
        {
            // needs to be replaced by death animation
            gameObject.SetActive(false);
            characterDied = true;

            if (isPlayer)
            {

            }
            return;
        }
        if (!isPlayer)
        {
            // make the enemy stagger with animation
            // play only when enemy is in vulnerable state
            if (takehit)
            {
                if (enemyAI.state == EnemyAi.State.Vulnerable)
                {
                    // play stagger animation
                }
            }

        }
    }

   
}
