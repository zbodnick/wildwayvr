using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{

	public GameObject[] trackPrefabs;
	public float zSpawn = 0;
	public float trackLen = 40;
	public int currNumTracks = 5;
    public int numTracks = 7;

    public Transform playerTransform;
    private List<GameObject> activeTracks;
    private int previousIndex;
    private string previousTrackTag = "Flat";

    private Dictionary<string, int[]> trackPairs;

    // Start is called before the first frame update
    void Start()
    {

        activeTracks = new List<GameObject>();
        GenerateTrackPairs();

    	// Generate first few tracks
    	for (int i = 0; i < currNumTracks; i++) {
    		SpawnTrack();
    	}

        playerTransform = playerTransform.transform;
        
    }

    private void GenerateTrackPairs() {

        int[] startWithFlat = new int[] {0, 1, 2};
        int[] startWithHill = new int[] {3, 4};
        int[] startWithCliff = new int[] {5, 6};

        trackPairs = new Dictionary<string, int[]>();

        trackPairs.Add("Flat", startWithFlat);
        trackPairs.Add("Hill", startWithHill);
        trackPairs.Add("Cliff", startWithCliff);

    }

    // Update is called once per frame
    void Update()
    {

    	// If player is at end of track, spawn a new one
    	if (playerTransform.position.z - (3*trackLen) >= zSpawn - (currNumTracks * trackLen)) {
            PopTrack(); 
            SpawnTrack();
    	}

    }

    private int RandomTrack() {
        return Random.Range(0, numTracks);
    }

    // GenerateTrackPairs determine what track can be generated considering previousIndex and the following matching scheme:
    
    // BridgeTrack - needs FlatToHill or FlatToCliff
    // CliffToFlat - needs FlatToHill or FlatToCliff
    // HillToFlat - needs FlatToHill or FlatToCliff

    // CliffToHill - needs HillToCliff or HillToFlat
    // FlatToHill - needs HillToCliff or HillToFlat

    // HillToCliff - needs CliffToHill or CliffToFlat
    // FlatToCliff - needs CliffToHill or CliffToFlat

    public void SpawnTrack() {

        GameObject track;

        int[] validTracks = trackPairs[previousTrackTag];
        int newTrackIndex = validTracks[Random.Range(0, validTracks.Length)];
        
        while (newTrackIndex == previousIndex) {
            newTrackIndex = validTracks[Random.Range(0, validTracks.Length)];
        }
            
        
        track = Instantiate (trackPrefabs[newTrackIndex]) as GameObject;

        track.transform.position = Vector3.forward * zSpawn;
        track.transform.rotation = Quaternion.identity;

        previousTrackTag = track.tag;
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