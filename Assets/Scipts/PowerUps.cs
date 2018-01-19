using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

    public bool doublePoints;
    public bool safeMode;

    public float powerupLength;

    private PowerupManager thePowerupManager;

    public Sprite[] powerupSprites;

    private AudioSource DoubleCoinSound;
    private AudioSource RemoveSpikeSound;

    private int SelectorTemp;

    // Use this for initialization
    void Start () {
        thePowerupManager = FindObjectOfType<PowerupManager>();
        DoubleCoinSound = GameObject.Find("DoubleCoinSound").GetComponent<AudioSource>();
        RemoveSpikeSound = GameObject.Find("RemoveSpikeSound").GetComponent<AudioSource>();
    }

    private void Awake()
    {
        int powerupSelector = Random.Range(0, 2);

        switch (powerupSelector)
        {
            case 0: doublePoints = true;
                SelectorTemp = powerupSelector;
                break;
            case 1: safeMode = true;
                SelectorTemp = powerupSelector;
                break;
        }

        GetComponent<SpriteRenderer>().sprite = powerupSprites[powerupSelector];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            thePowerupManager.ActivatePowerup(doublePoints, safeMode, powerupLength);
            gameObject.SetActive(false);

            switch (SelectorTemp)
            {
                case 0:
                    if (DoubleCoinSound.isPlaying)
                    {
                        DoubleCoinSound.Stop();
                        DoubleCoinSound.Play();
                    }
                    else
                    {
                        DoubleCoinSound.Play();
                    }
                    break;
                case 1:
                    if (RemoveSpikeSound.isPlaying)
                    {
                        RemoveSpikeSound.Stop();
                        RemoveSpikeSound.Play();
                    }
                    else
                    {
                        RemoveSpikeSound.Play();
                    }
                    break;
            }
        }
    }
}
