using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 camera = new Vector3(target.position.x, target.position.y, transform.position.z);
            gameObject.transform.position = camera;
        }
    }
}
