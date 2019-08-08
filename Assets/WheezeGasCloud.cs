using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheezeGasCloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IEnumerator killTimer = deathTimer(5);
        StartCoroutine(killTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<playerController>().DieAndRespawn();
        }
    }

    IEnumerator deathTimer(int duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);

    }
}
