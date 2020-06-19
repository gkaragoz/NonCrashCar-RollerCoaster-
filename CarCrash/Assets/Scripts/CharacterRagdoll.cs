using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterRagdoll : MonoBehaviour
{
    public PuppetMaster pm;
    public Animator anim;
    public GameObject target;
    public Vector3 offset;
    public Rigidbody hitPart;
    public float jumpForce;
    public bool isMoving;
    private void Update()
    {
        if (isMoving)
        {
            transform.position = target.transform.position - offset;

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Explosion();
        }
    }


    public void Explosion()
    {
        isMoving = false;
        anim.enabled = false;
        hitPart.velocity = Vector3.zero;
        hitPart.AddForce(Vector3.up * jumpForce);
        pm.state = PuppetMaster.State.Dead;

    }

}
