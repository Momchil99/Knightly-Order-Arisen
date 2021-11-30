using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
public LayerMask collisionLayer;
public float radius = 1f;
public float damage = 10f;

public bool is_Player, is_Enemy;

public GameObject hit_FX; 

    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }

    void DetectCollision(){
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if (hit.Length > 0)
        {
            Debug.Log("We Hit the " + hit[0].gameObject.name);

            gameObject.SetActive(false);

            //Create hit FX to let player know they are htting the enemy

            hit[0].GetComponent<Health>().ApplyDamage(damage, true);
            
        }
    }
}
