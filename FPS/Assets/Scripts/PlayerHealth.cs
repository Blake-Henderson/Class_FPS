using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text healthText;
    public int health = 100;

    void Start()
    {
        ApplyDamage(0);
    }

    void ApplyDamage(int damage)
    {
        if (healthText != null && health > 0)
        {
            health -= damage;
            healthText.text = "Health: " + health;
        }
    }
}
