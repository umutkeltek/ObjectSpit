using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private bool ToggleSlowMoo;

    public void ToggleSlowMo(bool state)
    {
        ToggleSlowMoo = state;
    }
}