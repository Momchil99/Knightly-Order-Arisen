using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject swordAttackPoint;

    public GameObject enemyAttackLeft;
    public GameObject enemyAttackRight;

    void SwordAttackPointOn()
    {
        swordAttackPoint.SetActive(true);
       
    }

    void SwordAttackPointOff()
    {
        if (swordAttackPoint.activeInHierarchy)
        {
            swordAttackPoint.SetActive(false);
        }
    }

    // enemy attack point scripts

    void EnemyAttackLeftOn()
    {
        enemyAttackLeft.SetActive(true);

    }

    void EnemyAttackLeftOff()
    {
        if (enemyAttackLeft.activeInHierarchy)
        {
            enemyAttackLeft.SetActive(false);
        }
    }
    void EnemyAttackRightOn()
    {
        enemyAttackRight.SetActive(true);

    }

    void EnemyAttackRightOff()
    {
        if (enemyAttackRight.activeInHierarchy)
        {
            enemyAttackRight.SetActive(false);
        }
    }
    
    // ends enemy attack point scripts
}
