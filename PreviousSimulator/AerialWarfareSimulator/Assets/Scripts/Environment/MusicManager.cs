using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    private AudioSource player;

    void Awake() {

        // Load AudioSource component
        player = GetComponent<AudioSource>();

        // Initialize list of all available music clips
        List<string> musicNames = new List<string> {
            "Electric Universe - Bansuri",
            "Electric Universe - Embracing The Sun",
            "Electric Universe - Morning Star",
            "Electric Universe - One Love",
            "Electric Universe - Quasar",
            "Electric Universe - Science",
            "Electric Universe - The Bomb"
        };

        // Randomly selects a music name
        int selectedMusicId = Random.Range(0, musicNames.Count);
        string selectedMusicName = "Music/" + musicNames[selectedMusicId];

        // Loads the audio clip
        AudioClip audioClipToLoad = Resources.Load(selectedMusicName) as AudioClip;

        // Set the audio clip on audio source
        player.clip = audioClipToLoad;

        // Plays the clip
        player.Play();
    }
}
