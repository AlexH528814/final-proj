using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    public static float pubrotation;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;    
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        pubrotation = rotZ;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
