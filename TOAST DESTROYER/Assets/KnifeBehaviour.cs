using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : MonoBehaviour
{
    private const int followSpeed = 20; // scaling factor on movement speed
    
    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;        transform.position = Vector2.MoveTowards(
                transform.position, mousePos, followSpeed*Time.deltaTime);
    }
}
