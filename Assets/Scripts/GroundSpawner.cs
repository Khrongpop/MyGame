using UnityEngine;
public class GroundSpawner : MonoBehaviour {

    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile (bool spawnsItems = true) {
        GameObject temp = Instantiate (groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild (1).transform.position;

        if (spawnsItems) {
            temp.GetComponent<GroundTile> ().SpawnObstacle ();
            temp.GetComponent<GroundTile> ().SpawnCoin ();
            
        }
    }

    // Start is called before the first frame update
    void Start () {
        for (int i = 0; i < 15; i++) {
            if (i < 3) {
                  SpawnTile (false);
            } else {
                SpawnTile ();
            }
        }
    }

}