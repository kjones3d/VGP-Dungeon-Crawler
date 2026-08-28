using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base Quest class - represents any quest in the game
/// Week 3 - Day 1: OOP Fundamentals
/// </summary>
public class Quest
{
    // PROPERTIES - Data that describes a quest
    public string questName;
    public string description;
    public bool isComplete;
    public int currentProgress;
    public int requiredProgress;

    // CONSTRUCTOR - Creates a new quest object
    public Quest(string name, string desc, int required)
    {
        questName = name;
        description = desc;
        requiredProgress = required;
        currentProgress = 0;
        isComplete = false;
    }

    /// <summary>
    /// Updates the quest progress
    /// </summary>
    public void UpdateProgress(int amount)
    {
        // TODO: Add amount to currentProgress
        currentProgress += amount;
        // TODO: Call CheckCompletion()
        CheckCompletion();
        Debug.Log(questName + " progress: " + currentProgress + "/" + requiredProgress);
    }

    /// <summary>
    /// Checks if the quest is complete
    /// </summary>
    public void CheckCompletion()
    {
        if (currentProgress >= requiredProgress)
        {
            isComplete = true;
            Debug.Log("QUEST COMPLETE: " + questName);
        }
    }

    /// <summary>
    /// Returns quest information as a string
    /// </summary>
    public string GetQuestInfo()
    {
        // TODO: Return a formatted string with quest info
        // Example: "Quest: Defeat Goblins (3/5) - Not Complete"
        
        string status = isComplete ? "Complete" : "In Progress";

        string questInfo = "Quest: " + description + " (" + currentProgress + "/" + requiredProgress + ") - " + status;


        return questInfo;
    }
}
