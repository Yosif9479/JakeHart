﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour {
	public AudioClip sound;
	public GameObject effect;

    private void Start()
    {
        if (TheGate.currentUnlockedGateId >= GlobalValue.levelPlaying)
        {
            KeyUI.Instance.Used();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject == GameManager.Instance.Player.gameObject) {
			if (effect)
				Instantiate (effect, transform.position, Quaternion.identity);
            SoundManager.PlaySfx(sound);
			GameManager.Instance.isHasKey = true;
            //gameObject.SetActive (false);
            Destroy(gameObject);
        }
	}
}
