﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyBase
{
    void Update()
    {
        Following();
        CheckDeath();
    }

    protected override void Attack()
    {
        //ближняя атака
    }
}
