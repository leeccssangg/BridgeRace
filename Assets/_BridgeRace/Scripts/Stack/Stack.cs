using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stack : AllPool
{
    public SpawnObject spawnObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
}
