using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBagScript : MonoBehaviour
{
    public ParticleSystem WaterParticles;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(WaterParticles, transform.position, Quaternion.identity);
        Instantiate(WaterParticles, transform.position, Quaternion.identity);
        Instantiate(WaterParticles, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
