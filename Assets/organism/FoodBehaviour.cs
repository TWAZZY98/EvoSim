using UnityEngine;

public class FoodBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private float ammOfFood;
    private int foodrechargeSpeed;
    void Start()
    {
        ammOfFood = 100;
        foodrechargeSpeed = 5;
    }

    void Update()
    {
        ammOfFood = ammOfFood + Time.deltaTime * foodrechargeSpeed;

    }
    public void DecreeseFood()
    {
        ammOfFood = ammOfFood - 10;
    }
}
