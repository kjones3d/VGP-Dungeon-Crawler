using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Specialized quest for defeating enemies
/// Week 3 - Day 2: Inheritance
/// </summary>
// TODO: Make this class inherit from Quest using : Quest
public class DefeatQuest : Quest
{
    // NEW property specific to DefeatQuest
    // TODO: Declare public string enemyType
    public string enemyType;

    // CONSTRUCTOR - calls base constructor
    public DefeatQuest(string name, string desc, int required, string type) : base(name, desc, required)
    {
        // TODO: Initialize enemyType = type
        enemyType = type;
    }
    
    /// <summary>
    /// Called when an enemy is defeated
    /// </summary>
    public void OnEnemyDefeated(string defeatedType)
    {
        // TODO: Check if defeatedType matches this quest's enemyType
        if (defeatedType == enemyType)
        {
            UpdateProgress(1);
        }
    }
}
