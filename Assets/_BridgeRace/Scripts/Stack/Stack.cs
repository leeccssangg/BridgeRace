using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stack : AllPool
{
    public SpawnObject spawnObject;

    public void MoveToPlayerJump(BaseActor baseActor)
    {
        this.transform.parent = baseActor.backPosition;
        transform.localRotation = Quaternion.identity;
        //if (baseActor is Player)
        //{
        //    Vibration.Vibrate(5);
        //}
        this.transform.DOLocalJump(Vector3.up * baseActor.objHave * 0.02f, 0.75f, 1, 0.2f);
    }

    public void MoveToEnemyJump(BaseEnemy baseEnemy)
    {
        this.transform.parent = baseEnemy.backPosition;
        transform.localRotation = Quaternion.identity;
        //if (baseActor is Player)
        //{
        //    Vibration.Vibrate(5);
        //}
        this.transform.DOLocalJump(Vector3.up * baseEnemy.objHave * 0.02f, 0.75f, 1, 0.2f);
    }
}


