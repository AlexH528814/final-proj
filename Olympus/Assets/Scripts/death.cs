using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string curscene = SceneManager.GetActiveScene().name;

        if (collision.CompareTag("player"))
        {
            SceneManager.LoadScene(curscene);
        }
    }
}
