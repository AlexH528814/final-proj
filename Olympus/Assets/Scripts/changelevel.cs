using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changelevel : MonoBehaviour
{
    public crossscriptfunction function;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        function.inotherscript(collision);

    }
}
