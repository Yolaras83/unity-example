using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCoin : MonoBehaviour
{
    public float Delay = 4f;
    public Transform player;
    public Transform Coin;
    public GameObject CoinGO;
    public bool canSpawn;
    public float destroy;
    public bool destroy2;
    public Text coinCounter;
    public float CollectedCoins = -1f;


    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        destroy = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(SpawnCoinCoroutine());
        }
    }

    public IEnumerator SpawnCoinCoroutine()
    {
        canSpawn = false;

        // Wait for the specified delay
        yield return new WaitForSeconds(Delay);

        // Randomly choose a position within the specified range
        Vector3 spawnPosition = new Vector3(Random.Range(2.26f, 6.74f), player.position.y, player.position.z + 10);

        // Instantiate the coin at the chosen position
        var copy = Instantiate(CoinGO, spawnPosition, Quaternion.identity);

        // Allow spawning again
        canSpawn = true;

        Destroy(copy, destroy);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Coin(Clone)") ;
        {
            CollectedCoins = CollectedCoins + 1;
            // Check if the collided object is the player
            Debug.Log("e");
            Destroy(GameObject.Find("Coin(Clone)"));
            coinCounter.text = CollectedCoins.ToString();
        }
    }
}