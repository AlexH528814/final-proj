using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crossscriptfunction : MonoBehaviour
{
    public GameObject canvas;
    public GameObject startmenucanvas;
    public GameObject optionscanvas;
    public GameObject obj;
    public GameObject portal;
    public void inotherscript(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            string scene = SceneManager.GetActiveScene().name;
            if (scene == "Level1") SceneManager.LoadScene("normal_end"); // SceneManager.LoadScene("Level2");
        }

        if (SceneManager.GetActiveScene().name == "torture")
        {
            if (collision.CompareTag("pain"))
            {
                //Debug.Log("hi");
                StartCoroutine(CanvasEnable());
                
                Destroy(collision.gameObject, 0.1f);
            }

            if (collision.CompareTag("player") && name == "portal")
            {
                //Debug.Log("hi");
                SceneManager.LoadScene("torture_end");
            }
        }
    }

    public void StartNormalGame()
    {
        life.lives = 3;
        SceneManager.LoadScene("Level1");
        
    }

    public void StartTortureGame()
    {
        SceneManager.LoadScene("torture");
    }

    public void OpenOptions()
    {
        startmenucanvas.SetActive(false);
        optionscanvas.SetActive(true);
    }

    public void CloseOptions()
    {
        optionscanvas.SetActive(false);
        startmenucanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("startscene");
    }

    IEnumerator CanvasEnable()
    {
        canvas.SetActive(true);
        portal.SetActive(true);
        yield return new WaitForSeconds(3);
        canvas.SetActive(false);
        
    }
}
