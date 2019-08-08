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

    public IEnumerator wakeupStage1Timer;
    public IEnumerator wakeupStage2Timer;

    // Start is called before the first frame update
    void Start()
    {
        wakeupStage2Timer = wakeupTimeStage2(cycleDuration * 2);
        waterCycleTimer = waterCycle(cycleDuration);
        StartCoroutine(waterCycleTimer);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }


    private void OnCollisionEnter2D(Collision2D collision)
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

                else if(jumped)
                {
                    Destroy(collision.gameObject);
                    if (fertilizer == 2)
                    {
                        Debug.Log("i m in fertilizer");
                        // StartCoroutine("wakeupTimeStage1");
                        StopCoroutine(wakeupStage2Timer);
                        wakeupStage1Timer = wakeupTimeStage1(cycleDuration);
                        StartCoroutine(wakeupStage1Timer);
                    }

                    else if (fertilizer == 3)
                    {
                        StopCoroutine(wakeupStage1Timer);
                        wakeupStage2Timer = wakeupTimeStage2(cycleDuration*2);
                        StartCoroutine(wakeupStage2Timer);
                    }


                }

            }
        }

    }


    public override void harvest()
    {
        Destroy(gameObject);
        //Instantiate Fruit.
        Vector3 offset = new Vector3(0, 0.5f, 0);
        Instantiate(fruitPrefab, transform.position + offset, Quaternion.identity);



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
               // harvest();
                break;
        }
    }

    override public void disablePlantEffects()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = disabledSprite;
        jump = false;
        jumped = false;
    }

    override public void enablePlantEffects()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = phase1;
        jump = true;
        jumped = false;
    }

    public IEnumerator wakeupTimeStage1(int duration)
    {
        yield return new WaitForSeconds(duration);
        jumped = false;

    }

    public IEnumerator wakeupTimeStage2(int duration)
    {
        yield return new WaitForSeconds(duration);

        jumped = false;

    }


}
