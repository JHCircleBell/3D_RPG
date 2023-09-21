using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharaterStats
{
    public override void Die()
    {
        base.Die();

        // todo.. 죽는 모션 실행

        Destroy(gameObject);
    }
}
