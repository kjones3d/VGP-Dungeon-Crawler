using UnityEngine;

public enum collectType
{
    Key,
    Food
}

public enum foodType
{
    none,
    Drumstick,
    Ham,
    Jug,
    Turkey
}

public class Collectable : MonoBehaviour
{
    public collectType collectType;
    public foodType foodType;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(collectType == collectType.Key && foodType != foodType.none)
        {
            Debug.Log("Keys are not food. Fix this.");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(collectType == collectType.Key)
            {
                //Add a key to the player
            }
            if (collectType == collectType.Food)
            {
                switch (foodType)
                {
                    case foodType.Drumstick:
                        other.gameObject.GetComponent<PlayerHealth>().Heal(25);
                        break;
                    case foodType.Ham:
                        other.gameObject.GetComponent<PlayerHealth>().Heal(50);
                        break;
                    case foodType.Jug:
                        other.gameObject.GetComponent<PlayerHealth>().Heal(100);
                        break;
                    case foodType.Turkey:
                        other.gameObject.GetComponent<PlayerHealth>().Heal(200);
                        break;
                    default:
                        Debug.Log("Invalid Food Type");
                        break;

                }
            }
        }
        else { return; }
    }
}
