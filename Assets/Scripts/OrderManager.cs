using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public int easeDuration;
    public List<GameObject> listOfAvailablePlants = new List<GameObject>();

    public List<GameObject> OrderList = new List<GameObject>();
    public GameObject newOrderPrefab;
    private int timeAlive = 0;
    private bool myTimeStarted = false;
    private string fruitHit;
    public int ordersThisLevel;
    //public int actualOrdersThisLevel;
    int orderNumber = 0;
    bool allOrdersPlaced = false;
    int ordersMissedSoFar = 0;
    public int orderMissLimit;
    public bool triggered = false;

    public Animator monsterAnimator;

    void OnEnable()
    {
        EventSystem.timeTick += processTimeTick;
        EventSystem.orderMissedEvent += Fireball;
    }

    void OnDisable()
    {
        EventSystem.timeTick -= processTimeTick;
        EventSystem.orderMissedEvent -= Fireball;
    }

    // Start is called before the first frame update
    void Start()
    {
        //List<Order> newOrderList = new List<Order>();
        /*listOfAvailablePlants.Add(new Order("Orange", 40, null));
        listOfAvailablePlants.Add(new Order("Apple", 40, null));
        listOfAvailablePlants.Add(new Order("sdf", 40, null));
        listOfAvailablePlants.Add(new Order("asdasd", 40, null));*/
    }

    // Update is called once per frame
    void Update()
    {
        if (!allOrdersPlaced)
        {
            CreateOrder();
        }
    }

    void processTimeTick(int a)
    {
        if(!myTimeStarted)
        {
            timeAlive = 0;
            myTimeStarted = true;
        }
        else
        {
            timeAlive++;
        }
    }

    void CreateOrder()
    {
        
         if(orderNumber<ordersThisLevel)   
       //if (OrderList.Count < ordersThisLevel-1)
        {

            if (timeAlive % easeDuration == 0 && timeAlive != 0)
            {
                //Debug.Log("5");
                Debug.Log(Random.Range(0, listOfAvailablePlants.Count));
                
                int newIndex = Random.Range(0, listOfAvailablePlants.Count);
                GameObject xyz = listOfAvailablePlants[newIndex];
                GameObject orderToAdd = Instantiate(xyz, new Vector3(500, 500, 500),Quaternion.identity);
                Debug.Log(orderToAdd.GetComponent<Order>().plantName);

                orderToAdd.GetComponent<Order>().setOrderManager(gameObject.GetComponent<OrderManager>());
                OrderList.Add(orderToAdd);
                
                GameObject orderUI = Instantiate(newOrderPrefab, transform.position, Quaternion.identity);
                orderUI.GetComponent<OrderItemDisplay>().Prime(orderToAdd.GetComponent<Order>());
                orderUI.transform.SetParent(GameObject.Find("OrderPanel").transform, false);
                orderUI.transform.position = new Vector3(transform.position.x, transform.position.y, 0);



                timeAlive = 0;
                orderNumber++;
            }
            if(orderNumber == ordersThisLevel)
            {
                allOrdersPlaced = true;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //get name from collided fruit and populate fruitHit 
        if (collision.gameObject.tag == "fruit")
        {
            FruitBehavior currentFruit = collision.gameObject.GetComponent<FruitBehavior>();
            fruitHit = currentFruit.returnFruitName();
            removeFruitFromList(fruitHit, collision.gameObject);
            Debug.Log("Ate a " + fruitHit.ToString());
            monsterAnimator.SetInteger("monsterState", 0);
        }
    }

    public void removeFruitFromList(string fruitName, GameObject thrownFruit)
    {
        for(int i=0; i<OrderList.Count;i++)
        {
            if(OrderList[i].GetComponent<Order>().plantName == fruitName)
            {
                OrderList[i].GetComponent<Order>().orderCompleted();
                OrderList.RemoveAt(i);
                Destroy(thrownFruit);
                triggered = false;
                break;
                            }
        }
    }
    public void Fireball(int a)
    {
        ordersMissedSoFar++;
        if (ordersMissedSoFar == orderMissLimit)
        {
            monsterAnimator.SetInteger("monsterState", 2);
            Debug.Log("Angry!");
            ordersMissedSoFar = 0;
            
        }
        else
        {
            monsterAnimator.SetInteger("monsterState", 1);
            triggered = true;

        }
    }

    public void removeFruitAt(GameObject listObject)
    {
        OrderList.Remove(listObject);
    }
}
