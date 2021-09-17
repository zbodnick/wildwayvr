using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{

	public GameObject[] trackPrefabs;
	public float zSpawn = 0;
	public float trackLen = 40;
	public int currNumTracks = 3;
    public int numTracks = 3;

    public Transform playerTransform;
    private List<GameObject> activeTracks;
    private int previousIndex;


    // Start is called before the first frame update
    void Start()
    {

        activeTracks = new List<GameObject>();
        SpawnTrack();

    	// Generate first few tracks
    	for (int i = 0; i < currNumTracks; i++) {

    		if (i == 0) {
    			SpawnTrack();
    		} else {
    			SpawnTrack(RandomTrack());
    		}

    	}

        playerTransform = playerTransform.transform;
        
    }

    // Update is called once per frame
    void Update()
    {

    	// If player is at end of track, spawn a new one
    	if (playerTransform.position.z >= zSpawn - (currNumTracks * trackLen)) {
            int index = RandomTrack();
            // while(index == previousIndex) {
            //     index = RandomTrack();
            // }

            PopTrack();
            SpawnTrack(index);
    	}

    }

    private int RandomTrack() {
        return Random.Range(0, numTracks);
    }

    public void SpawnTrack(int trackIndex = 0) {

    	GameObject track;
        track = Instantiate (trackPrefabs[trackIndex]) as GameObject;

        track.transform.position = Vector3.forward * zSpawn;
        track.transform.rotation = Quaternion.identity;
        track.SetActive(true);

        activeTracks.Add(track);
    	zSpawn += trackLen;
        previousIndex = trackIndex;

    }

    private void PopTrack() {
        activeTracks[0].SetActive(false);
        activeTracks.RemoveAt(0);
    }

}