using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    public int sceneNumber;
    public bool levelDone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator deleteScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneNumber);
    }

    private void OnJoin()
    {
        if (levelDone)
        {
            Debug.Log("Scene");
            SceneManager.LoadScene(sceneNumber);
            gameObject.SetActive(false);
            levelDone = false;
        }
    }

    public void endLevel()
    {
        StartCoroutine("deleteScene");
    }
}
