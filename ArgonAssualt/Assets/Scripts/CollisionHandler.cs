using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {
    [SerializeField] float levelDelay = 1f;
    [SerializeField] GameObject deathFX;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("LoadSceneWhenDead", levelDelay);
    }

    void LoadSceneWhenDead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
