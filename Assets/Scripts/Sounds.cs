using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip jump;
    public AudioClip die;
    public AudioClip boost;
    public AudioClip enemyDeath;
    public AudioClip finishHim;

    static AudioClip jumpSound;
    static AudioClip dieSound;
    static AudioClip boostSound;
    static AudioClip enemyDeathSound;
    static AudioClip finishHimSound;

    static AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        jumpSound = jump;
        dieSound = die;
        boostSound = boost;
        enemyDeathSound = enemyDeath;
        finishHimSound = finishHim;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playJump()
    {
        audio.PlayOneShot(jumpSound);
    }

    public static void playDie()
    {
        audio.PlayOneShot(dieSound);
    }

    public static void playBoost()
    {
        audio.PlayOneShot(boostSound);
    }

    public static void playEnemyDeath()
    {
        audio.PlayOneShot(enemyDeathSound);
    }

    public static void playFinishHim()
    {
        audio.PlayOneShot(finishHimSound);
    }

}
