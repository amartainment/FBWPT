using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("deleteScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator deleteScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}
