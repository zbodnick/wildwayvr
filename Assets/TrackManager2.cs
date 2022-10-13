using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager2 : MonoBehaviour {

    public GameObject[] trackPrefabs;
    public float zSpawn;
    public float trackLen;
    public int currNumTracks;
    public int numTracks;

    public float gapSize = 30;

    public Transform playerTransform;
    private List<GameObject> activeTracks;
    private int previousIndex;

    private bool isFirst = true;

    private Dictionary<string, int[]> trackPairs;

    void Start() {

        activeTracks = new List<GameObject>();

        // Generate first few tracks
        for (int i = 0; i < currNumTracks; i++) {
            if (i > 0) isFirst = false;
            SpawnTrack();
        }

        playerTransform = playerTransform.transform;
        
    }

    void Update() {

        // If player is at end of track, spawn a new one & pop a track
        if (playerTransform.position.z - trackLen >= zSpawn - (currNumTracks * trackLen)) {
            PopTrack(); 
            SpawnTrack();
        }

    }

    private int RandomTrack() {
        return Random.Range(0, numTracks);
    }


    public void SpawnTrack() {

        GameObject track;

        if (isFirst) {
            track = Instantiate (trackPrefabs[0]) as GameObject;
        } else {
            track = Instantiate (trackPrefabs[RandomTrack()]) as GameObject;
        }

        zSpawn += gapSize;
        track.transform.position = Vector3.forward * zSpawn;

        track.transform.rotation = Quaternion.identity;

        track.SetActive(true);

        activeTracks.Add(track);
        zSpawn += trackLen;

    }

    private void PopTrack() {
        activeTracks[0].SetActive(false);
        activeTracks.RemoveAt(0);
    }
}