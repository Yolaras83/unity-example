using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
    public Animator anim;
    public Movement PMovement;
    public GameObject CoinSpawner;
    public GameObject Banana;


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

        float randomValue = Random.Range(0f, 1f);

        // Randomly choose a position within the specified range
        Vector3 spawnPosition = new Vector3(Random.Range(2.26f, 6.74f), player.position.y, player.position.z + 10);

        // Instantiate the coin at the chosen position
        if (randomValue > 0.5f)
        {
            var copy = Instantiate(CoinGO, spawnPosition, Quaternion.identity);

            Destroy(copy, destroy);
        }

        // Allow spawning again
        canSpawn = true;

        if (randomValue <= 0.5f)
        {
            var copy2 = Instantiate(Banana, spawnPosition, Quaternion.identity);
    
        Destroy(copy2, destroy);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Coin(Clone)")
        {
            CollectedCoins = CollectedCoins + 1;
            // Check if the collided object is the player
            Debug.Log("e");
            Destroy(GameObject.Find("Coin(Clone)"));
            coinCounter.text = CollectedCoins.ToString();
        }

        if (collision.GetComponent<BoxCollider>().CompareTag("Banana"))
        {
            StartCoroutine(Respawn());
        }
    }

    public IEnumerator Respawn()
    {
        canSpawn = false;
        PMovement.enabled = false;
        CollectedCoins = 0f;
        anim.SetBool("Lose", true);
        coinCounter.text = CollectedCoins.ToString();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}