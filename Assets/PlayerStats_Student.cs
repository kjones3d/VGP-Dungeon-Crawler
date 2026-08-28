using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages player stats and collectibles using dictionaries
/// Week 2 - Day 3: Dictionaries
/// </summary>
public class PlayerStats : MonoBehaviour
{
    [Header("UI References")]
    public Text healthText;
    public Text keysText;
    public Text coinsText;
    public Text potionsText;

    // Player Stats Dictionary - stores stat name and value
    // TODO: Declare Dictionary<string, int> playerStats
    Dictionary<string, int> playerStats;

    #region PlayerInput
    private PlayerInput playerInput;
    private void OnEnable()
    {
        playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        playerInput.Player.Disable();
    }

    private void Awake()
    {
        playerInput = new PlayerInput();
    }
    #endregion

    void Start()
    {
        // TODO: Initialize the dictionary
        playerStats = new Dictionary<string, int>();
        
        // TODO: Add initial stats
        playerStats.Add("health", 100);
        playerStats.Add("keys", 0);
        playerStats.Add("coins", 0);
        playerStats.Add("potions", 0);
        
        UpdateUI();
    }
    
    /// <summary>
    /// Collects a key and updates the stats
    /// </summary>
    public void CollectKey()
    {
        // TODO: Increase "keys" stat by 1
        playerStats["keys"]++;
        
        Debug.Log("Key collected! Total keys: " + playerStats["keys"]);
        UpdateUI();
    }
    
    /// <summary>
    /// Collects a coin and updates the stats
    /// </summary>
    public void CollectCoin()
    {
        // TODO: Safely increase "coins" stat by 1
        // IMPORTANT: Use ContainsKey() to check first!
        if (playerStats.ContainsKey("coins"))
        {
            playerStats["coins"]++;
        }

        Debug.Log("Coin collected! Total coins: " + playerStats["coins"]);
        UpdateUI();
    }
    
    /// <summary>
    /// INDEPENDENT PRACTICE: Collects a potion
    /// </summary>
    public void CollectPotion()
    {
        // TODO: Safely increase "potions" stat by 1
        // Remember to use ContainsKey()!
        if(playerStats.ContainsKey("potions"))
        {
            playerStats["potions"]++;
        }
        UpdateUI();
    }
    
    /// <summary>
    /// Uses a potion to restore health
    /// </summary>
    public void UsePotion()
    {
        // TODO: Check if player has potions
        if (playerStats["potions"] > 0)
        {
            // Decrease potions
            playerStats["potions"]--;

            // Increase health (max 100)
            playerStats["health"] += 25;
            if (playerStats["health"] > 100)
            {
                playerStats["health"] = 100;
            }

            Debug.Log("Used potion! Health: " + playerStats["health"]);
        }

        UpdateUI();
    }
    
    /// <summary>
    /// Updates the UI to display current stats
    /// </summary>
    void UpdateUI()
    {
        // TODO: Update each UI text element with dictionary values
        // Check if key exists before accessing!

        if (healthText != null && playerStats.ContainsKey("health"))
        {
            healthText.text = "Health: " + playerStats["health"];
        }

        // TODO: Do the same for keys, coins, and potions
        if (keysText != null && playerStats.ContainsKey("keys"))
        {
            keysText.text = "Keys: " + playerStats["keys"];
        }
        if (coinsText != null && playerStats.ContainsKey("coins"))
        {
            coinsText.text = "Coins: " + playerStats["coins"];
        }
        if (potionsText != null && playerStats.ContainsKey("potions"))
        {
            potionsText.text = "Potions: " + playerStats["potions"];
        }
    }
    
    /// <summary>
    /// Displays all stats (for debugging)
    /// </summary>
    public void DisplayAllStats()
    {
        Debug.Log("===== PLAYER STATS =====");

        // TODO: Loop through dictionary and display each stat
        foreach (KeyValuePair<string, int> stat in playerStats)
        {
            Debug.Log(stat.Key + ": " + stat.Value);
        }
    }


    // TESTING: Uncomment to test with keyboard
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.K)) CollectKey();
    //     if (Input.GetKeyDown(KeyCode.C)) CollectCoin();
    //     if (Input.GetKeyDown(KeyCode.P)) CollectPotion();
    //     if (Input.GetKeyDown(KeyCode.U)) UsePotion();
    //     if (Input.GetKeyDown(KeyCode.D)) DisplayAllStats();
    // }

    /*
    private void Update()
    {
        if (playerInput.Player.K.triggered)
        {
            CollectKey();
        }
        if (playerInput.Player.C.triggered)
        {
            CollectCoin();
        }
        if (playerInput.Player.P.triggered)
        {
            CollectPotion();
        }
        if (playerInput.Player.U.triggered)
        {
            UsePotion();
        }
        if (playerInput.Player.D.triggered)
        {
            DisplayAllStats();
        }
    }
    */
}
