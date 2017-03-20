using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpawnBlocks : MonoBehaviour
{


	public GameObject[] Block;
	public int spawnBlocknum = 4;
	private int randNum;
	public float xMinRange = -7.0f;
	public float xMaxRange = 7.0f;
	public float yMinRange = -3.5f;
	public float yMaxRange = 3.5f;



	// Use this for initialization
	void Awake ()
	{
		MakeBlocksSpawn ();
	}


	public void MakeBlocksSpawn ()
	{
		randNum = Random.Range (0, Block.Length);
		Vector2 spawnPos;

		spawnPos.x = Random.Range (xMinRange, xMaxRange);
		spawnPos.y = Random.Range (yMinRange, yMaxRange);
		int i = 0;
		while (i < spawnBlocknum)
		{
			GameObject BlockObject = Instantiate (Block[randNum], spawnPos, transform.rotation) as GameObject;
			float scale = Random.Range (0.8f, 3.0f); 
			BlockObject.transform.localScale = new Vector3 (scale, scale, 0f);
			Vector2 newSpawnPos;
			newSpawnPos.x = Random.Range (xMinRange, xMaxRange);
			newSpawnPos.y = Random.Range (yMinRange, yMaxRange);

			if (newSpawnPos.x == spawnPos.x && newSpawnPos.x>0) {
				spawnPos.x = newSpawnPos.x-3;
			}
			else if (newSpawnPos.x == spawnPos.x && newSpawnPos.x<0) {
				spawnPos.x = newSpawnPos.x+3;
			} else {
				
				spawnPos.x = newSpawnPos.x;
			}

			if (newSpawnPos.y == spawnPos.y && newSpawnPos.y>0) {
				spawnPos.y = newSpawnPos.y-2;
			} 
			else if (newSpawnPos.y == spawnPos.y && newSpawnPos.y<0) {
				spawnPos.y = newSpawnPos.y+2;
			} else {
				
				spawnPos.y = newSpawnPos.y;
			}
			i++;
		}
	}
}
