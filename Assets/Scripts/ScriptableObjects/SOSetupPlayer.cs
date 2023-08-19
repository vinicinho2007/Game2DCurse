using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOSetupPlayer : ScriptableObject
{
    [Header("Config.Movement e Jump")]
    public float speed;
    public float speedRun;
    public float forceJump;
    public Vector2 friction;

    [Header("Animation")]
    public string jumpAnim;
    public string jumpTriggerGroundAnim;
    public string animKill;
    public string nameRun;
    public string nameSpeedRun;
    public float tempDelayKill;
}