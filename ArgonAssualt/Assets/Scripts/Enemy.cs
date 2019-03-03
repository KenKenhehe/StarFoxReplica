using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] GameObject enemyDeathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hit = 10;

    ScoreBoard scoreBoard;
	// Use this for initialization
	void Start () {
        AddNontriggerCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
	}

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(hit);
        hit--;
        //scoreBoard.ScoreHit(scorePerHit);
        if (hit <= 1)
        {
            KillEneny();
            scoreBoard.ScoreHit(scorePerHit);
        }
    }

    void AddNontriggerCollider()
    {
        Collider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    void KillEneny()
    {
        Debug.Log("hit < 10");
        Destroy(gameObject);
        GameObject fx = Instantiate(enemyDeathFX, gameObject.transform.position, Quaternion.identity);
        fx.transform.parent = parent;
    }
}

  

