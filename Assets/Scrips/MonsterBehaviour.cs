using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MonsterBehaviour : MonoBehaviour, Hittable {

    public GameOverManager gameOverManager;

    private int _sleepiness; 
	private bool _asleep;
	public Material awakeMaterial;
	public Slider awakeSlider;
	public int startingSleepiness = 30;

    private bool startled = false;
    // Image to display when monster is startled
    public Image startledImage;
    // Speed at which the startled image fades
    public float flashSpeed = 5f;
    public Color startleColor = new Color(1f, 0f, 0f, 0.3f);

    AudioSource monsterAudio;
    public AudioClip awakeNoise;

	// Use this for initialization
	void Start () {
        monsterAudio = GetComponent<AudioSource>();
		_sleepiness = startingSleepiness;
		awakeSlider.maxValue = startingSleepiness;
		awakeSlider.value = 0;

		_asleep = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if(startled)
        {
            // Make the screen flash some colour to let player know monster is startled.
            startledImage.color = startleColor;
        } else
        {
            // Fade the startled colour back to clear.
            startledImage.color = Color.Lerp(startledImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        startled = false;
	}

	void SetAsleep(bool asleep) {
		_asleep = asleep;
	}

	public bool IsAsleep() {
		return _asleep;
	}

	// From Hittable interface
	public void ReactToHit(int damage) {
		if (_asleep) {
			Debug.Log ("Monster has been hit.");
			_sleepiness -= damage;
			// Remember, have to use StartCoroutine; can't just call the co-routine.
			StartCoroutine (Startle ());
			// Bar goes from empty (fully asleep) to full (awake)
			awakeSlider.value = startingSleepiness - _sleepiness;

			if (_sleepiness <= 0) {
				StartCoroutine(WakeUp ());
			}
		}
	}

	/*
	 * Make the monster looks a little startled to let player know 
	 * that it's been hit and is waking up.
	 */
	private IEnumerator Startle() {
        startled = true;
        // Play the grunt sound
        monsterAudio.Play();
        
		this.transform.Rotate (-30, 0, 0);
        
		yield return new WaitForSeconds (0.2f);
		this.transform.Rotate (30, 0, 0);
	}

	private IEnumerator WakeUp() {
		
		_asleep = false;
        monsterAudio.clip = awakeNoise;
        monsterAudio.Play();

		Renderer renderer = GetComponent<Renderer> ();
		// Change the way the monster looks to let player know it's awake.
		if (awakeMaterial != null) {
			renderer.material = awakeMaterial;
		}

        // Monster noise has a trail-off, so start playing ending animation 
        // during the trail-off rather than waiting for it to finish completely.
        yield return new WaitForSeconds(1);

        StartCoroutine(gameOverManager.GameOver());
	}
}