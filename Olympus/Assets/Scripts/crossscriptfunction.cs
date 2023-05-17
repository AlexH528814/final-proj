using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crossscriptfunction : MonoBehaviour
{
    public void inotherscript(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {

            string scene = SceneManager.GetActiveScene().name;
            switch (scene)
            {
                case "Level1":
                    Debug.Log("changed");
                    SceneManager.LoadScene("Level3");
                    break;

                case "Level2":
                    SceneManager.LoadScene("Level3");
                    break;

                case "Level3":
                    SceneManager.LoadScene("End");
                    break;
            }
        }
    }
}
