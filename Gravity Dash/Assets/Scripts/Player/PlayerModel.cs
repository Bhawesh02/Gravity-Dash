

using System.Collections.Generic;
using UnityEngine;

public class PlayerModel 
{
    public int IncreaseMassDuration { get;private set; }
    public int MassChange { get;private set; }
    public float Speed { get; private set; }
    public bool OnGround;
    public bool ExtraLife;
    public Vector3 LastPlayerPos;

    public List<Vector3> LastPlatformPos = new();


    public Vector3 LastBackgroundPos;
    public Vector3 LastGameEndPos;

    public float LastGravityScale;

    public bool LastFlipY;

    public Dictionary<GameObject, Vector3> PickupsLastPos = new();

    public PlayerModel(PlayerScriptableObject playerScriptableObject)
    {
        IncreaseMassDuration = playerScriptableObject.IncreaseMassDuration;
        MassChange = playerScriptableObject.MassChange;
        Speed = playerScriptableObject.Speed;
        OnGround = false;
        ExtraLife = false;
        LastPlayerPos = new();
        LastPlatformPos = new();
        LastBackgroundPos = new();
        LastGameEndPos = new();
        LastGravityScale = new();
        LastFlipY = false;
        PickupsLastPos = new();
    }
}
