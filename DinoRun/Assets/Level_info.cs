using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "ScriptableObjects/LevelInfo")]
public class Level_info : ScriptableObject
{
    public int level;
    public int PowerRequiredToBeatBoss;
}
