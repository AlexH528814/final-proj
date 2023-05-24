using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm : MonoBehaviour
{
	public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        music.Play();
    }
}
