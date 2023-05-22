using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crossscriptfunction : MonoBehaviour
{
    public GameObject canvas;
    public GameObject obj;
    public void inotherscript(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            string scene = SceneManager.GetActiveScene().name;
            if (scene == "Level1")  SceneManager.LoadScene("Level2");
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (collision.CompareTag("pain"))
            {
                Debug.Log("hi");
                StartCoroutine(CanvasEnable());
                
                Destroy(collision.gameObject, 3f);
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator CanvasEnable()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(3);
        canvas.SetActive(false);
        Destroy(obj);
    }
}
