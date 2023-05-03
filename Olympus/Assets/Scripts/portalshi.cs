using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalshi : MonoBehaviour
{
    public GameObject bluep;
    public GameObject redp;

    public float shootdistance = 1000000f;
    public Transform pgun;
    Rigidbody2D rb;

    public LayerMask hitable;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(pgun.rotation);

        float zang = pgun.rotation.eulerAngles.z;

        Debug.Log(zang);


        RaycastHit2D hit = Physics2D.Raycast(pgun.position, pgun.right, shootdistance, hitable);
        if (Input.GetMouseButton(0))
        {
            bluep.transform.position = hit.point;

            if (zang < 45 || zang > 315) bluep.transform.rotation = Quaternion.Euler(0, 0, 90);
            if (zang < 135 && zang > 45) bluep.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (zang > 135 && zang < 225) bluep.transform.rotation = Quaternion.Euler(0, 0, -90);
            if (zang > 225 && zang < 315) bluep.transform.rotation = Quaternion.Euler(0, 0, 180);
            
        }
        if (Input.GetMouseButton(1))
        {
            redp.transform.position = hit.point;
            if (zang < 45 || zang > 315) redp.transform.rotation = Quaternion.Euler(0, 0, 90);
            if (zang < 135 && zang > 45) redp.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (zang > 135 && zang < 225) redp.transform.rotation = Quaternion.Euler(0, 0, -90);
            if (zang > 225 && zang < 315) redp.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }
}
