using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance; // Singleton instance

    [Header("Audio Sources")]
    public AudioSource backgroundMusicSource; // For background music
    public AudioSource soundEffectSource;     // For sound effects

    [Header("Audio Clips")]
    public AudioClip[] musicTracks;   // Array of background music tracks
    public AudioClip[] soundEffects; // Array of sound effects

    private int currentTrackIndex = 0; // Current background music track index

    void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }

    void Start()
    {
        PlayMusic(currentTrackIndex); // Start with the first music track
    }

    // Background Music Controls
    public void PlayMusic(int trackIndex)
    {
        if (trackIndex < 0 || trackIndex >= musicTracks.Length) return;

        currentTrackIndex = trackIndex;
        backgroundMusicSource.clip = musicTracks[trackIndex];
        backgroundMusicSource.Play();
    }

    public void StopMusic()
    {
        backgroundMusicSource.Stop();
    }

    public void PauseMusic()
    {
        backgroundMusicSource.Pause();
    }

    public void ResumeMusic()
    {
        backgroundMusicSource.UnPause();
    }

    public void NextTrack()
    {
        int nextTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;
        PlayMusic(nextTrackIndex);
    }

    public void PreviousTrack()
    {
        int previousTrackIndex = (currentTrackIndex - 1 + musicTracks.Length) % musicTracks.Length;
        PlayMusic(previousTrackIndex);
    }

    public void SetVolume(float volume)
    {
        backgroundMusicSource.volume = Mathf.Clamp01(volume); // Volume range 0.0 to 1.0
    }

    // Sound Effect Controls
    public void PlaySoundEffect(int soundIndex)
    {
        if (soundIndex < 0 || soundIndex >= soundEffects.Length) return;

        soundEffectSource.PlayOneShot(soundEffects[soundIndex]);
    }

    public void SetSFXVolume(float volume)
    {
        soundEffectSource.volume = Mathf.Clamp01(volume); // Volume range 0.0 to 1.0
    }
}
