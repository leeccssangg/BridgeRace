using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class Enemy : BaseEnemy
{
    [SerializeField]
    private GameObject model;
    public GameObject[] UIEmoji;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    public Vector3 transObj;
    public Vector3 transBridge;
    public Vector3 transExit;
    public Vector3 transCheckIn;
    private NavMeshAgent nav;
    private Animator anim;
    [SerializeField]
    private LevelManager levelManager;
    private List<SpawnObject> spawnObjectWithType;
    private SpawnObject spawnPoint;
    private bool moveToSpawnPoint;
    public LayerMask layer;

    void Start()
    {
        base.Start();
        //animator = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        switch (this.spawnType)
        {
            case SpawnType.E1:
                spawnObjectWithType = levelManager.GetObjectWithSpawnTypeE1();
                break;
            case SpawnType.E2:
                spawnObjectWithType = levelManager.GetObjectWithSpawnTypeE2();
                break;
            case SpawnType.E3:
                spawnObjectWithType = levelManager.GetObjectWithSpawnTypeE3();
                break;

        }
        
        //CheckSpawnPoint();
        //transExit = GameManager.Instance.exitPos.position;
    }
    void Update()
    {
        base.Update();
        SwitchState();
        ChangeAnim();
        CheckCollectStack();
        Debug.Log(spawnObjectWithType.Count);
    }
    public override void MoveToCollect()
    {
        transObj = spawnPoint.transform.position;
        //this.transform.LookAt(transObj);
        navMeshAgent.SetDestination(transObj);
        navMeshAgent.stoppingDistance = 0;
    }
    public override void MoveToBridge()
    {
        //if (navMeshAgent.velocity.magnitude < 0.1f)
        //{
        //    Quaternion lookRotation = Quaternion.LookRotation(transBridge - transform.position);
        //    this.transform.rotation = lookRotation;
        //}
        ////this.transform.LookAt(placeEat.trans);
        //navMeshAgent.SetDestination(transBridge);
        //navMeshAgent.stoppingDistance = 0;
    }
    public override void BuildBridge()
    {
        //this.transform.LookAt(transCheckInLookAt);
        //if (navMeshAgent.velocity.magnitude < 0.1f)
        //    this.transform.DORotate(Vector3.zero, 0f);
        //navMeshAgent.SetDestination(transCheckIn);
        //navMeshAgent.stoppingDistance = 0;
    }
    public override void Idle()
    {
        if (navMeshAgent == null)
            return;
        if (navMeshAgent.velocity.magnitude < 0.1f)
        {
            //if (placeEat != null)
            //    this.transform.LookAt(placeEat.trans);
            //else
            this.transform.DORotate(Vector3.zero, 0f);
        }
    }
    private void ChangeAnim()
    {
        if (navMeshAgent.velocity.magnitude > 0.1f)
        {
            animator.Play("Running");
        }
        else
        {
            //if (STATE_ENEMY == BaseEnemy.COLLECT_STATE)
            //    animator.Play("");
            //else if (STATE_ENEMY == BaseEnemy.MOVE_TO_BRIDGE_STATE)
            //    animator.Play("");
            //else if (STATE_ENEMY == BaseEnemy.BUILD_BRIDGE_STATE)
            //    animator.Play("");
            //else if (STATE_ENEMY == BaseEnemy.FALL_STATE)
            //    animator.Play("");
            //else
            animator.Play("Idle");
        }
    }

    public override void Fall()
    {
       
    }

    private void SwitchState()
    {
        if (!moveToSpawnPoint)
        {
            CheckSpawnPoint();
        }
        else
        {
             UpdateState(COLLECT_STATE);
        }
        if(this.transform.position == transObj)
        {
            moveToSpawnPoint = false;
        }

    }

    private void CheckSpawnPoint()
    {
         int i = Random.Range(0, spawnObjectWithType.Count);
         if (spawnObjectWithType[i].numObj != 0)
         {
            spawnPoint = spawnObjectWithType[i];
            moveToSpawnPoint = true;
    
         }
         //else
         //{
         //   CheckSpawnPoint();
         //}   
    }

    public void CheckCollectStack()
    {
        foreach (Collider c in Physics.OverlapBox(transform.position, this.transform.localScale / 10, Quaternion.identity, layer))
        {
            if (c.TryGetComponent(out Stack stack))
            {
                if (stack.spawnObject.spawnType == this.spawnType)
                    if (!stacks.Contains(stack))
                    {
                        objHave++;
                        stack.spawnObject.numObj--;
                        stacks.Add(stack);
                        stack.MoveToEnemyJump(this);
                    }
            }
        }
    }
}

