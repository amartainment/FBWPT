using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTriggerPlant : PlantGrowth
{

    public float highJumpHeight;

    public bool jump = false;

    private bool jumped = false;

    public Sprite phase2;
    public Sprite phase3;
    public Sprite phase1;
    public Sprite disabledSprite;


    // Start is called before the first frame update
    void Start()
    {
        waterCycleTimer = waterCycle(cycleDuration);
        StartCoroutine(waterCycleTimer);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && jump)
        {
 
            if (fertilizer == 1)
            {
                collision.gameObject.GetComponent<JumpForceCharacter>().CharacterJump(highJumpHeight);
                Debug.Log("jump in collider");
            }
            if (fertilizer >= 2)
            {
                if (!jumped)
                {
                    collision.gameObject.GetComponent<JumpForceCharacter>().CharacterJump(highJumpHeight);
                    jumped = true;
                }

                else
                {
                    Destroy(collision.gameObject);
                    if (fertilizer == 2)
                    {
                        StartCoroutine("wakeupTimeStage1");
                    }

                    else if (fertilizer == 3)
                    {
                        StartCoroutine("wakeupTimeStage2");
                    }

                    jumped = false;
                }

            }
        }

    }

    public override void harvest()
    {
        Destroy(gameObject);
        //Instantiate Fruit.
        Debug.Log("Ready to harvest");

    }
    override public void changePhase(int number)
    {
        switch (number)
        {
            case 1:
                enablePlantEffects();
                break;
            case 2:
                enablePlantEffects();
                gameObject.GetComponent<SpriteRenderer>().sprite = phase2;
                break;
            case 3:
                enablePlantEffects();
                gameObject.GetComponent<SpriteRenderer>().sprite = phase3;
                break;
            case 4:
                harvest();
                break;
        }
    }

    override public void disablePlantEffects()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = disabledSprite;
        jump = false;
    }

    override public void enablePlantEffects()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = phase1;
        jump = true;
    }
    
    public IEnumerator wakeupTimeStage1()
    {
        yield return new WaitForSeconds(5f);
    }

    public IEnumerator wakeupTimeStage2()
    {
        yield return new WaitForSeconds(10f);
    }
}
