using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameoverManager : VyesSingleton<GameoverManager>
{
    public void Exit()
    {
        SceneLevelManager.Instance.GoToScene("MainMenu");
    }
}