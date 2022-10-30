using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitAnimation : MonoBehaviour
{
    public bool k;
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 50);
        if (k)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(Time.fixedTime) * 0.002f, transform.position.z);
        }
        
    }
}
