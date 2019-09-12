using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsData : MonoBehaviour
{
    public int[] allLevelsTapsAmounts = { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };

    public int getLevelTaps(int index)
    {
        return allLevelsTapsAmounts[index];
    }
}
