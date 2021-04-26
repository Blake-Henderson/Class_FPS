using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spawners
{
    public GameObject prefab;
    public bool isActive;

    public Spawners(GameObject go, bool active)
    {
        prefab = go;
        isActive = active;
    }
}

public class GameManager : MonoBehaviour
{
    public GameObject panel;
    public List<Spawners> spawner = new List<Spawners>();

    public delegate void RestartRounds();
    public static event RestartRounds RoundComplete;

    int health;
    int roundsSurvived;
    int currentRound;
    PlayerHealth playerHealth;
    Text panelText;

    void Start()
    {
        Time.timeScale = 1.0f;
        panel.SetActive(false);
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        panelText = panel.GetComponentInChildren<Text>();

        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (go.name.Contains("Spawner"))
            {
                Debug.Log("Found spawner");
                spawner.Add(new Spawners(go, true));
            }
        }
    }

    void Update()
    {
        int total = 0;
        health = playerHealth.health;

        if (health > 0)
        {
            for (int i = spawner.Count - 1; i >= 0; --i)
            {
                if (spawner[i].prefab.GetComponent<Spawner>().spawnsDead)
                {
                    ++total;
                }
            }

            if (total == spawner.Count && roundsSurvived == currentRound)
            {
                ++roundsSurvived;
                panelText.text = string.Format("Round {0} Completed!", roundsSurvived);
                panel.SetActive(true);
            }

            if (roundsSurvived != currentRound && Input.GetButton("Fire2"))
            {
                currentRound = roundsSurvived;
                RoundComplete();
                panel.SetActive(false);
            }
        }
        else
        {
            if (Input.GetButton("Fire2"))
            {
                Scene current = SceneManager.GetActiveScene();
                SceneManager.LoadScene(current.name);
            }
            else
            {
                panel.SetActive(true);
                panelText.text = string.Format("Survived {0} Rounds", roundsSurvived);
                Time.timeScale = 0;
            }
        }
    }
}
