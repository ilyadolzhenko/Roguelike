﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHero : MonoBehaviour
{
    void Start() 
    {
        
    }

    void Update()
    {
        var dir = Input.mousePosition - UnityEngine.Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
