using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Utilities.Components;
using DG.Tweening;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public Joystick joystick;
    public Image[] joystickImage;
    public Camera cam;
    public Player player;
    private void Start()
    {

    }
}
