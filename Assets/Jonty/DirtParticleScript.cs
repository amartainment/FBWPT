﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtParticleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyCountDown());
    }

    IEnumerator DestroyCountDown()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
