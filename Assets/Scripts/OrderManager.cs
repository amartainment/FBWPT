using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public int easeDuration;
    public List<Order> listOfAvailablePlants = new List<Order>();
    public List<Order> OrderList = new List<Order>();
    public GameObject newOrderPrefab;
    private int timeAlive = 0;
    private bool myTimeStarted = false;
    private string fruitHit;
    public int ordersThisLevel;
    int orderNumber = 0;
    bool allOrdersPlaced = false;
    //public List<Order> newOrderList = new List<Order>();

    //public GameObject 
    void OnEnable()
    {
        EventSystem.timeTick += processTimeTick;
    }

    void OnDisable()
    {
        EventSystem.timeTick -= processTimeTick;
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

                var xyz = listOfAvailablePlants[newIndex];
                Debug.Log(xyz.plantName);
                OrderList.Add(xyz);
                GameObject orderUI = Instantiate(newOrderPrefab, transform.position, Quaternion.identity);
                orderUI.GetComponent<OrderItemDisplay>().Prime(xyz);
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
            
        }
    }

    public void removeFruitFromList(string fruitName, GameObject thrownFruit)
    {
        for(int i=0; i<OrderList.Count;i++)
        {
            if(OrderList[i].plantName == fruitName)
            {
                OrderList[i].orderCompleted();
                OrderList.RemoveAt(i);
                Destroy(thrownFruit);
                break;
            }
        }
    }
}
