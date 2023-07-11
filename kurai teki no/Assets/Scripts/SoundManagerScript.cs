using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip hitSound, pickSound, shotSound, explosionSound, powerSound, putSound, lowSound, deadSound, plantSound, outSound, enemypatroldeadSound, ghostSound;
    static AudioSource _audioSource;

    public AudioClip[] clips;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

    }

    // Start is called before the first frame update
    void Start()
    {
        hitSound       =    Resources.Load<AudioClip>("hit");
        pickSound      =    Resources.Load<AudioClip>("pick");
        shotSound      =    Resources.Load<AudioClip>("shot");
        explosionSound =    Resources.Load<AudioClip>("explosion");
        powerSound     =    Resources.Load<AudioClip>("power");
        putSound       =    Resources.Load<AudioClip>("put");
        lowSound       =    Resources.Load<AudioClip>("low");
        deadSound      =    Resources.Load<AudioClip>("dead");
        plantSound     =    Resources.Load<AudioClip>("plant");
        outSound       =    Resources.Load<AudioClip>("out");
        enemypatroldeadSound        =    Resources.Load<AudioClip>("enemypatroldead");
        ghostSound = Resources.Load<AudioClip>("ghost");
        //_audioSource = GetComponent<AudioSource>();
        _audioSource.loop = false;
        _audioSource.clip = clips[Random.Range(0, clips.Length)];
        _audioSource.PlayOneShot(_audioSource.clip);
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "hit":
                _audioSource.PlayOneShot(hitSound);
                break;
            case "pick":
                _audioSource.PlayOneShot(pickSound);
                break;
            case "shot":
                _audioSource.PlayOneShot(shotSound);
                break;
            case "explosion":
                _audioSource.PlayOneShot(explosionSound);
                break;
            case "power":
                _audioSource.PlayOneShot(powerSound);
                break;
            case "put":
                _audioSource.PlayOneShot(putSound);
                break;
            case "low":
                _audioSource.PlayOneShot(lowSound);
                break;
            case "dead":
                _audioSource.PlayOneShot(deadSound);
                break;
            case "plant":
                _audioSource.PlayOneShot(plantSound);
                break;
            case "out":
                _audioSource.PlayOneShot(outSound);
                break;
            case "enemypatroldead":
                _audioSource.PlayOneShot(enemypatroldeadSound);
                break;
            case "ghost":
                _audioSource.PlayOneShot(ghostSound);
                break;
        }
    }

}
