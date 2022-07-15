using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : AllPool
{
    public Transform backPosition;
    public int objHave;
    public SpawnType spawnType;
    public List<Stack> stacks;
    public FsmSystem fsm = new FsmSystem();
    public static string IDLE_STATE = "idle_state";
    public static string COLLECT_STATE = "collect_state";
    public static string MOVE_TO_BRIDGE_STATE = "move_to_bridge_state";
    public static string BUILD_BRIDGE_STATE = "build_bridge_state";
    public static string FALL_STATE = "fall_state";


    public string STATE_ENEMY;

    protected void Start()
    {
        fsm.init(6);
        fsm.add(new FsmState(IDLE_STATE, null, OnIdleState));
        fsm.add(new FsmState(COLLECT_STATE, null, OnCollectState));
        fsm.add(new FsmState(MOVE_TO_BRIDGE_STATE, null, OnMoveToBridgeState));
        fsm.add(new FsmState(BUILD_BRIDGE_STATE, null, OnBuildState));
        fsm.add(new FsmState(FALL_STATE, null, OnFallState));
        UpdateState(IDLE_STATE);
        fsm.execute();
    }
    protected void Update()
    {
        fsm.execute();
    }
    public void UpdateState(string state)
    {
        fsm.setState(state);
        STATE_ENEMY = state;
    }
    private FsmSystem.ACTION OnCollectState(FsmSystem _fsm)
    {
        MoveToCollect();
        return FsmSystem.ACTION.END;
    }
    private FsmSystem.ACTION OnIdleState(FsmSystem _fsm)
    {
        Idle();
        return FsmSystem.ACTION.END;
    }
    private FsmSystem.ACTION OnMoveToBridgeState(FsmSystem _fsm)
    {
        MoveToBridge();
        return FsmSystem.ACTION.END;
    }
    private FsmSystem.ACTION OnBuildState(FsmSystem _fsm)
    {
        BuildBridge();
        return FsmSystem.ACTION.END;
    }
    private FsmSystem.ACTION OnFallState(FsmSystem _fsm)
    {
        Fall();
        return FsmSystem.ACTION.END;
    }
    public virtual void MoveToCollect()
    {

    }
    public virtual void MoveToBridge()
    {

    }
    public virtual void BuildBridge()
    {

    }
    public virtual void Fall()
    {

    }
    public virtual void Idle()
    {

    }
}
