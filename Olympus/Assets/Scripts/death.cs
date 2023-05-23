using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    public GameObject circle;
    public Transform circlespawn;
    public Canvas canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string curscene = SceneManager.GetActiveScene().name;

        if (curscene == "Level1" || curscene == "Level2")
        {
            if (collision.CompareTag("player") || collision.CompareTag("Player") && life.lives > 0)
            {
                SceneManager.LoadScene(curscene);
                Debug.Log(life.lives);
                life.lives--;
                Debug.Log(life.lives);
            }

            if (collision.CompareTag("player") && life.lives <= 0)
            {
                SceneManager.LoadScene("deathscene");
            }
        }

        if (curscene == "torture")
        {
            if (collision.CompareTag("player"))
            {
                SceneManager.LoadScene(curscene);
            }
        }
        
        if (collision.CompareTag("pain"))
        {
            Destroy(collision.gameObject);
            Instantiate(circle, circlespawn.position, circlespawn.rotation);
        }
    }
}
