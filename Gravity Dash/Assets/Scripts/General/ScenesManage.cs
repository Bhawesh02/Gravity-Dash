using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Scenes
{
    Lobby,
    Level1,
    level2
}
public static class ScenesManage 
{
    public static string GetSceneName(Scenes name)
    {
        switch(name)
        {
            case Scenes.Lobby:return "Lobby";
            case Scenes.Level1:return "Level1";
            case Scenes.level2:return "Level2";
            default: Debug.LogError("Wrong Scene Name");
                return null;
        }
    }
}
