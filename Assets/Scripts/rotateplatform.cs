using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateplatform : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Rotate(new Vector3(0, 360, 0) * Time.deltaTime * speed);
    }
}
