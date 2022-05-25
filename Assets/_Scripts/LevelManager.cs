using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    [SerializeField] private int collectedTemporaryGold = 0;

    public void AddTemporaryGold(int enemyValue)
    {
        collectedTemporaryGold = enemyValue + collectedTemporaryGold;
    }

    public void EndLevel(int multiply)
    {
        GameManager.Instance.totalGold = GameManager.Instance.totalGold + (collectedTemporaryGold * multiply);
        collectedTemporaryGold = 0;
    }
}
