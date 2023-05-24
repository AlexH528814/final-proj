using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introtext_torture : MonoBehaviour
{
    public GameObject canvas;

    public float time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        if (!restart.hasRestarted_torture)
        StartCoroutine(enumerator());   
    }

    
    IEnumerator enumerator()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(time);
        canvas.SetActive(false);
    }
}
