using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    
    public static int[] playerNumbers = { 1, 2, 3, 4 };
    
        // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void assignPlayerNumbers(playerController player)
    {
        for (int i=0;i<4;i++)
        {
            if (playerNumbers[i] != 0) 
            {
                player.playerNumber = playerNumbers[i];
                assignColor(playerNumbers[i], player.gameObject.GetComponent<SpriteRenderer>());
                playerNumbers[i] = 0;
                break;
            }
        }
    }

    public void assignColor(int playerNumber, SpriteRenderer playerSprite)
    {
        switch (playerNumber)
        {
            case 1:
                playerSprite.color = new Color32(255, 255, 255, 255);
                //set player 1 to top left
                playerSprite.gameObject.transform.position = new Vector3(-7, 4, 0);
                break;
            case 2:
                playerSprite.color = new Color32(255, 0, 0, 255);
                playerSprite.gameObject.transform.position = new Vector3(8, 4, 0);

                break;
            case 3:
                playerSprite.color = new Color32(255, 255, 0, 255);
                playerSprite.gameObject.transform.position = new Vector3(-7, -2.5f, 0);

                break;
            case 4:
                playerSprite.color = new Color32(0, 255, 255, 255);
                playerSprite.gameObject.transform.position = new Vector3(8, -2.5f, 0);

                break;
        }
    }


}
