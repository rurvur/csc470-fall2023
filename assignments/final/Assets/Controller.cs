using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float speed = 20;
    float turnSpeed = 100;
    float jumpPower = 15;
    float gravityMod = 5f;
    float yVel = 0;
    float power = 100;
    int health;
    int maxhealth;
    int level;
    int exp;
    int toNextLevel;
    public GameObject Manager;
    public GameObject FireballPrefab;
    int fireCool;
    int frame;
    

    CharacterController cc;
    Renderer rend;


    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        rend = gameObject.GetComponentInChildren<Renderer>();
        maxhealth = 10;
        health = maxhealth;
        level = 1;
        exp = 0;
        toNextLevel = 10;
        fireCool = 0;
        frame = 0;
        Manager = GameObject.Find("SceneManager");
    }

    public void updateStats(string stat, float change)
    {
        if (stat == "speed")
        {
            speedChange(change);
        }
        else if (stat == "turnSpeed")
        {
            turnSpeedChange(change);
        }
        else if (stat == "power")
        {
            powerChange(change);
        }
    }

    void speedChange (float speedchange)
    {
        speed += speedchange;
    }

    void turnSpeedChange (float speedchange)
    {
        turnSpeed += speedchange;
    }

    void powerChange(float powerchange)
    {
        power += powerchange;
    }

    void LevelUp()
    {
        updateStats("speed", 1);
        updateStats("power", 1);
        maxhealth++;
        health = maxhealth;
        level += 1;
        if (level % 5 == 0)
        {
            turnSpeedChange(1f);
        }
    }

    public string getHealth()
    {
        return health.ToString();
    }

    public string getMax()
    {
        return maxhealth.ToString();
    }

    public string getLevel()
    {
        return level.ToString();
    }

    public void giveEXP(int val)
    {
        exp += val;
    }

    void GameOver()
    {
        Manager.GetComponent<SceneChanger>().ChangeScene("GameOver");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        frame++;
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        transform.Rotate(0, hAxis * turnSpeed * Time.deltaTime, 0, Space.Self);
        if (!cc.isGrounded)
        {
            yVel += Physics.gravity.y * gravityMod * Time.deltaTime;
        }
        else
        {
            yVel = -1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cc.isGrounded)
            {
                yVel = jumpPower;
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (fireCool < 0)
            {
                Vector3 pos = transform.position;
                GameObject fireball = Instantiate(FireballPrefab, pos, transform.rotation);
                fireCool = 10;
            }
        }

        if (exp >= toNextLevel)
        {
            LevelUp();
            exp -= toNextLevel;
            toNextLevel += toNextLevel;
        }

        Vector3 amountToMove = vAxis * transform.forward * speed;
        amountToMove.y = yVel;
        cc.Move(amountToMove * Time.deltaTime);

        if (health <= 0)
        {
            GameOver();
        }
        if (frame % 30 == 0)
        {
            fireCool--;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemies"))
        {
            health -= 1;
            Destroy(other.gameObject);
        }
        
    }
}
