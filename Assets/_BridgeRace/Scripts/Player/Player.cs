using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : BaseActor
{
    public LayerMask layer;
    public float animSpd;
    private float tmpspeed;
    [SerializeField]
    private GameObject Money;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }
    public Vector2 Config(Vector2 input)
    {
        if (input.magnitude >= 0.09)
        {
            return input;
        }
        return Vector2.zero;
    }
    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (Config(GameManager.Instance.joystick.Direction) != Vector2.zero)
        {
             UpdateState(RUN_STATE);
        }
        else UpdateState(IDLE_STATE);
        CheckCollectStack();
    }

    public override void UpdateMove(float speed)
    {
        Joystick joystick = GameManager.Instance.joystick;
        Vector2 inputAxist = joystick.Direction;
        var rig = GetComponent<Rigidbody>();
        rig.velocity = new Vector3(joystick.Horizontal * speed, rig.velocity.y, joystick.Vertical * speed);
        animSpd = rig.velocity.magnitude;
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Vector3 moveDir = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
            transform.rotation = Quaternion.LookRotation(moveDir).normalized;
        }
    }

    public void CheckCollectStack()
    {
        foreach(Collider c in Physics.OverlapBox(transform.position, this.transform.localScale/10 , Quaternion.identity, layer))
        {
            if(c.TryGetComponent(out Stack stack))
            {
                if(stack.spawnObject.spawnType == SpawnType.PLAYER)
                if (!stacks.Contains(stack))
                {
                    objHave++;
                    stack.spawnObject.numObj--;
                    stacks.Add(stack);
                    stack.MoveToPlayerJump(this);
                }          
            }
        }
    }
}
