using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCharacter : MonoBehaviour
{
    private Animator anim;
    private Player player;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GetComponent<Player>();
    }
    private void UpdateAnim(string state)
    {
        if (state == null || anim == null)
            return;
        anim.SetFloat("Speed", player.animSpd);
        if (state == "idle_state")
        {
            //if (player.objHave > 0)
            //{
            //    anim.Play("IdleCarring");
            //}
            //else
                anim.Play("Idle");
        }
        if (state == "run_state")
        {
            //if (player.objHave > 0)
            //    anim.Play("RunningWithObject");
            //else
                anim.Play("Running");

        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateAnim(player.STATE_PLAYER);
    }
}
