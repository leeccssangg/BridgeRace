using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCustomer : AllPool
{
    public FsmSystem fsm = new FsmSystem();
    public static string IDLE_STATE = "idle_state";
    public static string EAT_STATE = "eat_state";
    public static string CHECK_IN_STATE = "check_in_state";
    public static string WAIT_TO_EAT = "wait_to_eat";
    public static string MOVE_TO_EAT_STATE = "move_to_eat_state";
    public static string EXIT_STATE = "exit_state";

    public string STATE_CUSTOMER;

    protected void Start()
    {
        fsm.init(6);
        fsm.add(new FsmState(IDLE_STATE, null, OnIdleState));
        fsm.add(new FsmState(CHECK_IN_STATE, null, OnCheckInState));
        fsm.add(new FsmState(EXIT_STATE,null, OnExitState));
        fsm.add(new FsmState(MOVE_TO_EAT_STATE, null ,OnMovetoEatState));
        fsm.add(new FsmState(EAT_STATE, null, OnEatState));
        fsm.add(new FsmState(WAIT_TO_EAT, null, OnWaitToEatState));
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
        STATE_CUSTOMER = state;
    }
    private FsmSystem.ACTION OnCheckInState(FsmSystem _fsm)
    {
        MoveToCheckIn();
        return FsmSystem.ACTION.END;
    }
    private FsmSystem.ACTION OnIdleState(FsmSystem _fsm)
    {
        Idle();
        return FsmSystem.ACTION.END;
    }
    private FsmSystem.ACTION OnExitState(FsmSystem _fsm)
    {
        MoveToExit();
        return FsmSystem.ACTION.END;
    }
    private FsmSystem.ACTION OnMovetoEatState(FsmSystem _fsm)
    {
        MoveToEat();
        return FsmSystem.ACTION.END;
    }
    private FsmSystem.ACTION OnEatState(FsmSystem _fsm)
    {
        Eat();
        return FsmSystem.ACTION.END;
    }
    private FsmSystem.ACTION OnWaitToEatState(FsmSystem _fsm)
    {
        Eat();
        return FsmSystem.ACTION.END;
    }
    public virtual void MoveToCheckIn()
    {

    }
    public virtual void Eat()
    {

    }
    public virtual void MoveToExit()
    {

    }
    public virtual void MoveToEat()
    {

    }
    public virtual void Idle()
    {

    }
}
