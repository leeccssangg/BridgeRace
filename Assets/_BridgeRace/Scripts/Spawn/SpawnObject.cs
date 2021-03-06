using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Stack stack;
    public bool spawnAble;
    public int numObj;
    public int maxObj;
    private float timeDelaySpawn;
    public float timeDelay;
    public SpawnType spawnType;
  
    void Start()
    {
        timeDelaySpawn = timeDelay;
    }
    void Update()
    {
        Effect();
    }

    public void Effect()
    {
        if(numObj >= maxObj)
        {
            return;
        }
        if (spawnAble)
        {
            spawnAble = false;
            Spawn();
        }
        if (!spawnAble)
        {
            timeDelaySpawn -= Time.deltaTime;
        }
        if (timeDelaySpawn <= 0)
        {
            spawnAble = true;
            timeDelaySpawn = timeDelay;
        }
    }

    private void Spawn()
    {
        var g = AllPoolContainer.Instance.Spawn(stack, this.transform.position, transform.rotation);
        (g as Stack).spawnObject = this;
        numObj++;
    }
}

public enum SpawnType
{
    PLAYER,
    E1,
    E2,
    E3
}
