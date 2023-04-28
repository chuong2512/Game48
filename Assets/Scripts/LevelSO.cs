using System;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "ScriptableObject/Level SO",fileName = "Level raw data")]
public class LevelSO : ScriptableObject
{
    [SerializeField] private LevelData[] levelsData;

    public LevelData GetLevelData(int level)
    {
        var trueLevel = level % levelsData.Length; 
        
        return levelsData[trueLevel];
    }
}

[Serializable]
public class LevelData
{
    [FormerlySerializedAs("knife1")]
    [Tooltip("Knives Data")]
    [SerializeField] private Knife knife;
    [SerializeField] private float speed;
    [SerializeField] private int knivesAmount;

    [FormerlySerializedAs("virus")]
    [Space] [Tooltip("Virus Data")] 
    [SerializeField] private Cycle cycle;
    [SerializeField] private float cycleScale;
    [SerializeField] private float increaseSC;
    [SerializeField] private float cycleSpeed;

    public Knife Knife => knife;

    public float Speed => speed;

    public int KnivesAmount => knivesAmount;

    public Cycle Cycle => cycle;

    public float CycleScale => cycleScale;

    public float IncreaseSc => increaseSC;

    public float CycleSpeed => cycleSpeed;
}