using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        float speed = GameManager.Instance.Speed;
        Vector3 currPos = transform.position;
        currPos.x -= speed * Time.deltaTime;
        transform.position = currPos;
    }
}
