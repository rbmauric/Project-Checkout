using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxSpeed; //Fastest speed the player can move

    Rigidbody2D mybody2d; //Reference to Rigidbody2D in player model
    Animator anim; //Reference to animator and enable access to variables in unity
    private bool lookingright; //if character is facing right
    void Start()
    {
        mybody2d = GetComponent<Rigidbody2D>();//stores reference to Rigidbody2D in mybody2d
        anim = GetComponent<Animator>();//stores reference to Animator in anim
        lookingright = true;
    }

    // Update is called once per frame, always and all the time
    void FixedUpdate()
    {
        float adv = Input.GetAxis("Horizontal");//float value that changes depending if moving left or right/ -1 to 0 or 0 to 1

        anim.SetFloat("speed", Mathf.Abs(adv));

        mybody2d.velocity = new Vector2(adv*maxSpeed, mybody2d.velocity.y);//x variable of Rigidbody2D affected by adv, not y

        if(adv > 0 && !lookingright)//checking if character is looking right or not
        {
            flip();
        }
        else if(adv < 0 && lookingright )
        {
            flip();
        }
    }

    void flip()
    {
        lookingright = !lookingright;//if it was false, it is now true & if it was true, it is now false

        Vector3 scale = transform.localScale;//takes values from transform of player model and putting them in scale

        scale.x *= -1;//convert current x value to value on opposite scale from -1 to 1

        transform.localScale = scale; // place new value back into scale
    }
}
