using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurrowInteractTimer : MonoBehaviour
{
    GameObject InteractingGameObject, Player;
    public GameObject SeedType;
    public ParticleSystem DirtParticle;

    float Timer = 20;
    bool TimerisRunning;

    private void FixedUpdate()
    {
        if (Player != null && Player.GetComponent<Rigidbody2D>().velocity.magnitude > 0)
            InteractingGameObject = null;
            
    }

    public void TimerStart(GameObject IntPlayer, GameObject IntSeedType)
    {
        SeedType = IntSeedType;
        Player = IntPlayer;

        if(TimerisRunning == false)
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        TimerisRunning = true;
        InteractingGameObject = Player;

        while (InteractingGameObject != null && Timer > 0)
        {
            Timer -= 2.5f;
            Debug.Log("Burrow Timer = " + Timer);
            SeedType.transform.position -= new Vector3(0, 0.06f, 0);
            Instantiate(DirtParticle, (SeedType.transform.position), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }

        if (Timer <= 0)
        {
            gameObject.GetComponent<BurrowBehavior>().HeroInteract(SeedType, Player);
            Destroy(SeedType);
            InteractingGameObject = null;
            SeedType = null;
            Timer = 20;
        }

        Player = null;
        TimerisRunning = false;
    }

}
