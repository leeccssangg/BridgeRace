using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<SpawnObject> spawnObjects;
    public List<SpawnObject> spawnObjectWithTypeE1;
    public List<SpawnObject> spawnObjectWithTypeE2;
    public List<SpawnObject> spawnObjectWithTypeE3;

    void Awake()
    {
        //spawnObjectWithType = new List<SpawnObject>();
    }

    public List<SpawnObject> GetObjectWithSpawnTypeE1()
    {
        for (int i = 0; i < spawnObjects.Count; i++)
        {
            if (spawnObjects[i].spawnType == SpawnType.E1)
            {
                if (!spawnObjectWithTypeE1.Contains(spawnObjects[i]))
                {
                    spawnObjectWithTypeE1.Add(spawnObjects[i]);
                }
            }
        }
        return spawnObjectWithTypeE1;
    }

    public List<SpawnObject> GetObjectWithSpawnTypeE2()
    {
        for (int i = 0; i < spawnObjects.Count; i++)
        {
            if (spawnObjects[i].spawnType == SpawnType.E2)
            {
                if (!spawnObjectWithTypeE2.Contains(spawnObjects[i]))
                {
                    spawnObjectWithTypeE2.Add(spawnObjects[i]);
                }
            }
        }
        return spawnObjectWithTypeE2;
    }

    public List<SpawnObject> GetObjectWithSpawnTypeE3()
    {
        for (int i = 0; i < spawnObjects.Count; i++)
        {
            if (spawnObjects[i].spawnType == SpawnType.E3)
            {
                if (!spawnObjectWithTypeE3.Contains(spawnObjects[i]))
                {
                    spawnObjectWithTypeE3.Add(spawnObjects[i]);
                }
            }
        }
        return spawnObjectWithTypeE3;
    }

}
