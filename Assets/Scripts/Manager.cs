using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public GameObject[] Tracks;
    GameObject[] trackPieces;
    public GameObject player;
    int tracksPiecesMade = 0;
    Vector3 trackPos = Vector3.zero;
    Vector3 trackDisplace = new Vector3(0, -50, 55);
	// Use this for initialization
	void Start ()
    {
        Instantiate(Tracks[0], trackPos, Quaternion.Euler(-60,0,0));
        tracksPiecesMade++;
        trackPos += trackDisplace;
        InvokeRepeating("BuildLevel", 0, 1);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void BuildLevel()
    {
        if(tracksPiecesMade < 5)
        {
            Instantiate(Tracks[0], trackPos, Quaternion.Euler(-60, 0, 0));
            tracksPiecesMade++;
            trackPos += trackDisplace;
        }

        trackPieces = GameObject.FindGameObjectsWithTag("Track");
        for (int i = 0; i < trackPieces.Length; i++)
        {
            if (player.transform.position.y + 20 < trackPieces[i].transform.position.y)
            {
                Destroy(trackPieces[i]);
                tracksPiecesMade--;
            }
        }
    }
}
