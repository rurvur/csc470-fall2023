using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float forwardSpeed = 10;
    float rotateSpeed = 100;
    float jumpStrength = 15;
    float gravityMod = 5f;

    float yVelocity = 0;
    CharacterController cc;
    public GameObject bonusCol;
    public GameObject bonusWall;
    public GameObject coin;

    Renderer rend;
    int score;
    int playerState = 0;
    //0 for grounded
    //1 for midair
    //2 for midair, post double jump
    //3 for midair, post dash
    //4 for misair, post dash AND double jump

    public Color state0;
    public Color state1;
    public Color state2;
    public Color state3;
    public Color state4;

    int frame = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        cc = gameObject.GetComponent<CharacterController>();
        rend = gameObject.GetComponentInChildren<Renderer>();
        Application.targetFrameRate = 30;
        bonusCol.GetComponentInChildren<Collider>().isTrigger = true;
        bonusWall.GetComponentInChildren<Collider>().isTrigger = true;
        coin.GetComponentInChildren<Collider>().isTrigger = true;
    }

    void updateColor(int state)
    {
        if (state == 0)
        {
            rend.material.color = state0;
        }
        else if (state == 1)
        {
            rend.material.color = state1;
        }
        else if (state == 2)
        {
            rend.material.color = state2;
        }
        else if (state == 3)
        {
            rend.material.color = state3;
        }
        else
        {
            rend.material.color = state4;
        }
    }


    void Dash(Vector3 dashDist)
    {
        int framecount = frame;
        while (frame > framecount + 100)
        {
            
            if (frame % 10 == 0)
            {
                cc.Move(dashDist * Time.deltaTime);

            }
            else
            {
                frame++;
            }
            
        }
        return;
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        frame++;
        transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0, Space.Self);

        if (!cc.isGrounded)
        {
            yVelocity += Physics.gravity.y * gravityMod * Time.deltaTime;
            if (playerState == 0)
            {
                playerState = 1;
            }
        }
        else
        {
            yVelocity = -1;
            playerState = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerState == 0)
            {
                yVelocity = jumpStrength;
                playerState = 1;
            }
            else if (playerState == 1)
            {
                yVelocity = jumpStrength;
                playerState = 2;
            }
            else if (playerState == 3)
            {
                yVelocity = jumpStrength;
                playerState = 4;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector3 dashDist = (transform.forward * 500);
            dashDist.y = 0;
            if (playerState == 0)
            {
                cc.Move(dashDist * Time.deltaTime);
                playerState = 3;
            }
            else if (playerState == 2)
            {
                cc.Move(dashDist * Time.deltaTime);
                playerState = 4;
            }
            else if (playerState == 1)
            {
                cc.Move(dashDist * Time.deltaTime);
                playerState = 3;
            }
        }
        


        updateColor(playerState);

        Vector3 amountToMove = vAxis * transform.forward * forwardSpeed;
        amountToMove.y = yVelocity;
        cc.Move(amountToMove * Time.deltaTime);

    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bonus"))
        {
            playerState = 1;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Coin"))
        {
            score++;
            Destroy(other.gameObject);
            Debug.Log("COIN GET");
        }
    }
    
    
}
