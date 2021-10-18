using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManagerNew : MonoBehaviour {

    public GameObject[] trackPrefabs;
    public float zSpawn = 0;
    public float trackLen = 40;
    public int currNumTracks = 5;
    public int numTracks = 7;

    public Transform playerTransform;
    private List<GameObject> activeTracks;
    private int previousIndex;

    private Dictionary<string, int[]> trackPairs;

    void Start() {

        activeTracks = new List<GameObject>();

        // Generate first few tracks
        for (int i = 0; i < currNumTracks; i++) {
            SpawnTrack();
        }

        playerTransform = playerTransform.transform;
        
    }

    void Update() {

        // If player is at end of track, spawn a new one & pop a track
        if (playerTransform.position.z - (3*trackLen) >= zSpawn - (currNumTracks * trackLen)) {
            PopTrack(); 
            SpawnTrack();
        }

    }

    private int RandomTrack() {
        return Random.Range(0, numTracks);
    }


    public void SpawnTrack() {

        GameObject track;
        int newTrackIndex = RandomTrack();

        track = Instantiate (trackPrefabs[newTrackIndex]) as GameObject;

        track.transform.position = Vector3.forward * zSpawn;
        track.transform.rotation = Quaternion.identity;

        track.SetActive(true);

        activeTracks.Add(track);
        zSpawn += trackLen;
        previousIndex = newTrackIndex;

    }

    private void PopTrack() {
        activeTracks[0].SetActive(false);
        activeTracks.RemoveAt(0);
    }
}