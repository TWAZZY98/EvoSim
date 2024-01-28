using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class organism_script : MonoBehaviour
{
    [SerializeField] private int START_POINTS;
    private int hitPointsThreshold;
    private int hitPoints;
    private int damage;
    private int speed;
    private float agressionlvl;
    private int foodCap;
    private float food;
    private float foodChangeSpeed;
    
    private Transform target;

    public void Init() 
    {
        hitPoints = Random.Range(10,30);
        damage = Random.Range(10,30);
        speed = Random.Range(10,30);
        foodCap = Random.Range(10,30);
        food = foodCap;
        foodChangeSpeed = 1f / 60f;
        agressionlvl = START_POINTS - hitPoints + damage + speed + foodCap;
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
        Debug.Log("food cap: " +foodCap);
        Debug.Log("hit points: "+hitPoints);
        Debug.Log("Damage: " +damage);
        //target = GameObject.FindGameObjectWithTag("Finish").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(food);
        if (food != 0)
        {
            food = food - (Time.deltaTime * foodChangeSpeed * foodCap);
        }


        if (hitPoints < hitPointsThreshold *0.5 ) {
            if (food > 10)
            {
                food = food - 10;
                hitPoints = hitPoints + 5;
            }
        }

        if(food < foodCap * 0.35)
        {
            target = GameObject.FindGameObjectWithTag("Food").GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        

    }
}
