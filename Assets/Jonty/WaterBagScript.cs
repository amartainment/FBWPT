using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBagScript : MonoBehaviour
{
    public ParticleSystem WaterParticles;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine("destroyTimer");
    }

    public void WaterthePlant(GameObject Plant)
    {
        float PlantSegment;
        Vector3 startingposition;
        PlantSegment = Plant.transform.localScale.y / 3;
        startingposition = (Plant.transform.position - new Vector3(0, Plant.transform.localScale.y, 0));

        for (int i = 1; i <= 3; i++)
        {
            Instantiate(WaterParticles, (startingposition + new Vector3(0, PlantSegment * i, 0)), Quaternion.identity);
        }
    }

    IEnumerator destroyTimer()
    {
        yield return new WaitForSeconds(0.05f);
        Instantiate(WaterParticles, transform.position, Quaternion.identity);
        Instantiate(WaterParticles, transform.position, Quaternion.identity);
        Instantiate(WaterParticles, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
