using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public GameObject playerChar;

    public float initialPositionX;
    public float initialPositionY;
    public float initialPositionZ;



    // Start is called before the first frame update
    void Start()
    {
        initialPositionX = playerChar.transform.position.x;
        initialPositionY = playerChar.transform.position.y;
        initialPositionZ = playerChar.transform.position.z;

      
    }

    // Update is called once per frame
    void Update()
    {
       // playerChar.transform.position = new Vector3(initialPositionX, initialPositionY, initialPositionZ);
        Animation();
    }

    void  Animation()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerChar.GetComponent<Animator>().Play("Right Top Down Attack");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerChar.GetComponent<Animator>().Play("Dodge Left");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("A");
            playerChar.GetComponent<Animator>().Play("Parry");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerChar.GetComponent<Animator>().Play("Dodge Right");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerChar.GetComponent<Animator>().Play("Block");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            playerChar.GetComponent<Animator>().Play("Left Top Down");
        }

     

       /* public IEnumerator Animate()
        {
            anim[animClips[0]].speed = speed;
            anim.Play(animClips[0]);
            yield return WaitForAnim(anim[animClips[0]], speed);
        }

        IEnumerator WaitForAnim(AnimationState animclip, float spd)
        {
            tempTime = animclip.length * (1 / spd);
            yield return new WaitForSeconds(tempTime);
        }*/
    }

}

