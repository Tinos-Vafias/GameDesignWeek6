using System.Collections.Generic;
using UnityEngine;

public class ParrySound : MonoBehaviour
{
	public static ParrySound Instance { get; private set; }
	
	// unity audio variables
    [SerializeField] private AudioClip parrySound;
    private AudioSource audioSource;

	// music theory variables
	private const float Semitone = 1.059463f;
	private const float Microtone = 1.00057779f;
	/* D minor (F major) pentatonic scale - going D, F, G, A, C*/
	private List<int> PentatonicSemitones = new List<int>{ 1, 3, 2, 2, 3, 2 };
	
	// semitone variables 
	[SerializeField] private int semitoneChangeThreshold;
	private int semitoneChange;
	private int semitoneChangeIncrement = 10;


    private int playCounter;
	private int semitoneIndex;
    private float startingPitch;

	public bool isOn;
    public void Toggle()
    {
        isOn = !isOn;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps it alive between scenes
        }
        else
        {
            Destroy(gameObject); // Prevents duplicates
        }
		
		audioSource = GetComponent<AudioSource>();
        startingPitch = audioSource.pitch;
    }
	
    public void PlaySound()
    {		
		if (playCounter == semitoneChange)
		{
			playCounter = 0;
			semitoneIndex++;
			semitoneChange += semitoneChange + semitoneChangeIncrement;
			int pitch = PentatonicSemitones[semitoneIndex];
			audioSource.pitch *= Mathf.Pow(Semitone, pitch);
		}

		playCounter++;
		
		// adjust by a few microtones, makes it subtly less repetitive 
		float unadjustedPitch = audioSource.pitch;
		int microtoneRandomIncrement = Random.Range(10, 20);
		audioSource.pitch *= Mathf.Pow(Microtone, microtoneRandomIncrement);

		// play sound ONCE
		if (isOn)
		{
			audioSource.PlayOneShot(parrySound);
			audioSource.pitch = unadjustedPitch; // change back to without microtones
		}
    }
	
	public void ResetSemitone()
	{
		playCounter = 0;
		semitoneIndex = 0;
		semitoneChange = semitoneChangeThreshold;
		audioSource.pitch = startingPitch;
	}

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startingPitch = audioSource.pitch;
		semitoneChange = semitoneChangeThreshold;
    }
}