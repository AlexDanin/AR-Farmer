using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    private void Start()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    void Update()
    {
        if (gameObject.activeSelf)
        {
            // Quaternion rot = Quaternion.LookRotation(new Vector3(GameObject.Find("AR Session Origin").transform.position.x, transform.position.y, GameObject.Find("AR Session Origin").transform.position.z) - transform.position);
            // transform.rotation = Quaternion.Lerp(transform.rotation, rot, 500 * Time.deltaTime);
            transform.LookAt(new Vector3(GameObject.Find("AR Session Origin").transform.position.x, transform.position.y, -GameObject.Find("AR Session Origin").transform.position.z));
            // transform.LookAt(GameObject.Find("AR Session Origin").transform);
        }
    }
}
