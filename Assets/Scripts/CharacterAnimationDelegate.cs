using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject swordAttackPoint;

    // Start is called before the first frame update
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
}
