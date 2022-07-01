using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flappy : MonoBehaviour
{
    private Rigidbody2D flappyRigid;
    private SpriteRenderer flappyRenderer;
    private bool flying = false;
    [SerializeField] private float xSpeed;
    [SerializeField] private float spaceForce; // how much velocity will be added by pressing spacebar
    [SerializeField] private float fallSpeed;
    [SerializeField] private float rotationForce;
    private Shooter myShooter;
    
    // Start is called before the first frame update
    void Start()
    {
        flappyRigid = GetComponent<Rigidbody2D>();
        flappyRenderer = GetComponent<SpriteRenderer>();
        myShooter = GetComponentInChildren<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        flappyRigid.velocity = new Vector2(0, flappyRigid.velocity.y - fallSpeed);
        flappyRigid.transform.rotation = Quaternion.Euler(0, 0, rotationForce * flappyRigid.velocity.y);
        if (Input.GetKey(KeyCode.Space) && (!GameManager._shared.Over))
        {
            flappyRigid.velocity = new Vector2(0, flappyRigid.velocity.y + spaceForce);
            if (!flying)
            {
                flying = true;
                ClimbSoundManager._climb.PlaySound();
            }
        }
        else
        {
            ClimbSoundManager._climb.StopSound();
            flying = false;
        }



        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!GameManager._shared.Over)
            {
                myShooter.Shoot(transform);
            }

        }


        //flappyRenderer.transform.rotation = new Quaternion(0, 0, flappyRigid.velocity.y * rotationForce);


    }
}
