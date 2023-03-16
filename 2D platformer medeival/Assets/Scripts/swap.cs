using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class swap : MonoBehaviour
{
    public int sceneIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            StartCoroutine(Transition(sceneIndex));
        }
    }
    private IEnumerator Transition(int scene)
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(scene);
    }
}
