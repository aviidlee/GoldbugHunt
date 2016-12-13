using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

    public MonsterBehaviour monster;
    public SoundManager soundManager;
    public Replay replay;
    public AnimationClip clip;

    public bool gameover = false;

    public Animator anim;

	// Use this for initialization
	void Start () {
	
	}

    public IEnumerator GameOver()
    {
        anim.SetTrigger("GameOver");
        soundManager.GameOverSound();
        yield return new WaitForSeconds(3.0f);
        replay.EnableMenu();
    }

}
