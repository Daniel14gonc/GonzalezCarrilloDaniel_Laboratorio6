using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float camDistance;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height) / 2) / camDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        }

    }
}
