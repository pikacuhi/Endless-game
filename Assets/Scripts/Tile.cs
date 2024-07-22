using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] tilePrefabs;
    public float zSpawn;
    public float tileLength = 30;
    public int numberOfTiles = 5;

    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        for(int i = 0; i < numberOfTiles; i++){

            if(i == 0) SpawnTile(0); //startnya default dr tile index 0
            else
            SpawnTile(Random.Range(0,tilePrefabs.Length));//(min,max)
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - 35 > zSpawn - (numberOfTiles * tileLength)){
            SpawnTile(Random.Range(0 , tilePrefabs.Length));
            DelTile();
        }
    }

    public void SpawnTile(int tileIndex){
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);

        activeTiles.Add(go);

        zSpawn += tileLength;// 30 + 30+...
    }

    private void DelTile(){
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);

    }
}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Tile : MonoBehaviour
// {
//     // Start is called before the first frame update
//     public GameObject[] tilePrefabs;
//     public float zSpawn;
//     public float tileLength = 30; // Fix typo: tileLenght should be tileLength
//     public int numberOfTiles = 5;

//     void Start()
//     {
//         for (int i = 0; i < numberOfTiles; i++)
//         {
//             SpawnTile(Random.Range(0, tilePrefabs.Length)); 
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }

//     public void SpawnTile(int tileIndex)
//     {
//         Instantiate(tilePrefabs[tileIndex], new Vector3(0, 0, zSpawn), Quaternion.identity); // Fix typo: Quaternion.identity
//         zSpawn += tileLength; // Fix typo: tileLength
//     }
// }

