using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class Enemy : BaseEnemy
{
    public Animator[] animators;
    [SerializeField]
    private GameObject model;
    public GameObject[] UIEmoji;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    public Vector3 transObj;
    public Vector3 transBridge;
    public Vector3 transExit;
    public Vector3 transCheckIn;
    private void OnEnable()
    {
     
    }
    protected void Start()
    {
        base.Start();
        //animator = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        //transExit = GameManager.Instance.exitPos.position;
    }
    protected void Update()
    {
        base.Update();
        ChangeAnim();
        foreach (GameObject UI in UIEmoji)
        {
            if (UI.activeSelf)
            {
                UI.GetComponent<RectTransform>().DORotate(Vector3.right * 50, 0f);
            }
        }
    }
    public override void MoveToCollect()
    {
        this.transform.LookAt(transObj);
        navMeshAgent.SetDestination(transObj);
        navMeshAgent.stoppingDistance = 3;
    }
    public override void MoveToBridge()
    {
        if (navMeshAgent.velocity.magnitude < 0.1f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(transBridge - transform.position);
            this.transform.rotation = lookRotation;
        }
        //this.transform.LookAt(placeEat.trans);
        navMeshAgent.SetDestination(transBridge);
        navMeshAgent.stoppingDistance = 0;
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
    public void ChangeAnim()
    {
        if (navMeshAgent.velocity.magnitude > 0.1f)
        {
            animator.Play("Running");
        }
        else
        {
            if (STATE_ENEMY == BaseEnemy.COLLECT_STATE)
                animator.Play("CheckIn");
            else if (STATE_ENEMY == BaseEnemy.MOVE_TO_BRIDGE_STATE)
                animator.Play("Wait");
            else if (STATE_ENEMY == BaseEnemy.BUILD_BRIDGE_STATE)
                animator.Play("Eating");
            else if (STATE_ENEMY == BaseEnemy.FALL_STATE)
                animator.Play("Eating");
            else
                animator.Play("Idle");
        }
    }

    public override void Fall()
    {
       
    }
    public void StartUnlock(Vector3 pos)
    {
        foreach (GameObject UI in UIEmoji)
        {
            UI.SetActive(false);
        }
        navMeshAgent.SetDestination(pos);
        this.transform.LookAt(pos);
        navMeshAgent.stoppingDistance = 0;
    }
}
