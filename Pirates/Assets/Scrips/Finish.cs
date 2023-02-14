using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource exitSound ;
    private bool levelComplete = false;
    // Start is called before the first frame update
    private void Start()
    {
        exitSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelComplete)
        {   // call function after 2 seconds
            Invoke("LevelEnd", 2f);
            levelComplete = true;
            exitSound.Play();
        }
    }

    // load next level to play
    private void LevelEnd ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
