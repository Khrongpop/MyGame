using UnityEngine;

public class GroundTile : MonoBehaviour {
    GroundSpawner groundSpawner;
    [SerializeField] GameObject obstaclePrefab, coinPrefab, tallObstaclePrefab;
    [SerializeField] float tailObstacleChance = 0.2f;

    void Start () {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner> ();
    }

    private void OnTriggerExit (Collider other) {
        groundSpawner.SpawnTile ();
        Destroy (gameObject, 2);
    }
    // Obstacle

    public void SpawnObstacle () {

        // Choose which obstacle to spawn
        GameObject obstacleToSpawn = obstaclePrefab;
        float random = Random.Range (0f, 1f);
        if (random < tailObstacleChance) {
            obstacleToSpawn = tallObstaclePrefab;
        }

        // Choose a random point to spawn the obstacle
        int obstacleSpwnIndex = Random.Range (2, 5);
        Transform spawnPoint = transform.GetChild (obstacleSpwnIndex).transform;

        // Spawn the obstace at the position
        Instantiate (obstacleToSpawn, spawnPoint.position, Quaternion.identity, transform);
    }

    // Coin

    public void SpawnCoin () {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++) {
            GameObject temp = Instantiate (coinPrefab);
            temp.transform.position = GetRandomPointInCollider (GetComponent<Collider> ());
        }
    }

    Vector3 GetRandomPointInCollider (Collider collider) {
        int randomXPos = Random.Range (1, 4);
        int xPos = 0;

        switch (randomXPos) {
            case 1:
                xPos = -3;
                break;
            case 2:
                xPos = 3;
                break;
            default:
                break;
        }

        Vector3 point = new Vector3 (
            // Random.Range (collider.bounds.min.x, collider.bounds.max.x),
            xPos,
            Random.Range (collider.bounds.min.y, collider.bounds.max.y),
            Random.Range (collider.bounds.min.z, collider.bounds.max.z)
        );

        if (point != collider.ClosestPoint (point)) {
            point = GetRandomPointInCollider (collider);
        }

        point.y = 1;
        return point;
    }
}