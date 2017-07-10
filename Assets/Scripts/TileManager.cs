using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour 
{
	public GameObject[] tilePrefabs;

	private Transform playerTransform;
	private float spawnZ = 0.0f;
//	private float spawnX = -15.0f;
	private float tileLength = 24.0f;
	private int TilesOnScreen = 4;
	private float TimeBeforeTileDeletion = 20.0f;

	private List<GameObject> activeTiles;

	// Use this for initialization
	private void Start () 
	{
		activeTiles = new List<GameObject> ();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		for(int j=0 ; j < TilesOnScreen; j++)
		{
			SpawnTile(0);
		}

	}
	
	// Update is called once per frame
	private void Update () 
	{
		if (playerTransform.position.z - TimeBeforeTileDeletion > (spawnZ - tileLength * TilesOnScreen)) 
		{
			SpawnTile (Random.Range(0,3));
			DeleteTile (); 
		}
	}

	private void SpawnTile(int prefabIndex)
	{
		GameObject go;

		go = Instantiate (tilePrefabs [prefabIndex]) as GameObject;
		go.transform.SetParent (transform);

		go.transform.position = Vector3.forward * spawnZ ; //+ Vector3.right * spawnX
		spawnZ += tileLength;
		activeTiles.Add (go);
	}

	private void DeleteTile()
	{
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);
	}

}
