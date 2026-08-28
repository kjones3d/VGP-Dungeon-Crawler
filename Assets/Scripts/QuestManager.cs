using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public List<Quest> activeQuests = new List<Quest>();
    private void Start()
    {
        activeQuests.Add(new DefeatQuest("Kill Ghosts", "...", 3, "Ghost"));

    }

    void OnGUI()
    {
        GUI.Label(new Rect(200, 300, 300, 20), "Current Quest: " + activeQuests[0].questName + " Progress: " + activeQuests[0].currentProgress + " / " + activeQuests[0].requiredProgress);
    }
}
