using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseActor : AllPool
{
    public int objHave;
    public float timeDelayCatch;
    public bool canCatch = true;
    public List<Stack> stacks;
    public Transform backPosition;
    //public float health;
    public FsmSystem fsm = new FsmSystem();
    public static string IDLE_STATE = "idle_state";
    public static string RUN_STATE = "run_state";
    public static string FALL_STATE = "fall_state";

    public string STATE_PLAYER;
    public float speed;
    public void UpdateState(string state)
    {
        fsm.setState(state);
        STATE_PLAYER = state;
    }
    protected void Start()
    {
        fsm.init(4);
        fsm.add(new FsmState(IDLE_STATE, null, OnIdleState));
        fsm.add(new FsmState(RUN_STATE, null, OnRunState));
        fsm.add(new FsmState(FALL_STATE,OnFallState,null));
        UpdateState(IDLE_STATE);
        fsm.execute();
    }
    private FsmSystem.ACTION OnIdleState(FsmSystem _fsm)
    {
        return FsmSystem.ACTION.END;
    }
    private FsmSystem.ACTION OnRunState(FsmSystem _fsm)
    {
        UpdateMove(speed);
        return FsmSystem.ACTION.END;
    }
    private void OnFallState(FsmSystem _fsm)
    {
        Fall();
    }
    public virtual void UpdateMove(float speed)
    {

    }
    public virtual void Fall()
    {

    }
    // Update is called once per frame
    protected void Update()
    {
        fsm.execute();
    }
    public void DelayCatch(float time)
    {
        CounterHelper.Instance.QueueAction(time, () => 
        {
            canCatch = true;
        });
    }
}
