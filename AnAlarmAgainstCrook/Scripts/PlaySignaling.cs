using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySignaling : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;
    [SerializeField] private AudioSource _soundSigaling;
    [SerializeField] private float _volumeStep;

    private float _increase = 1;
    private float _decrease = 0;
    private float _volumeZero = 0;
    private Coroutine _ChangeVolumeSound;

    private void OnEnable()
    {
        _signaling.Reached += Play;
    }

    private void OnDisable()
    {
        _signaling.Reached -= Play;
    }

    public void Play(bool isPlaying)
    {
        if (isPlaying)
            AlarmStart();
        else
            AlarmStop();
    }

    public void AlarmStart()
    {
        StopCoroutineChangeVolume();

        _soundSigaling.volume = _volumeZero;
        _soundSigaling.Play();
        _ChangeVolumeSound = StartCoroutine(ChangeVolume(_volumeStep, _increase));
    }

    public void AlarmStop()
    {
        StopCoroutineChangeVolume();

        _ChangeVolumeSound = StartCoroutine(ChangeVolume(_volumeStep, _decrease));

        if (_soundSigaling.volume == _volumeZero)
        {
            _soundSigaling.Stop();
        }
    }

    private void StopCoroutineChangeVolume()
    {
        if (_ChangeVolumeSound != null)
        {
            StopCoroutine(_ChangeVolumeSound);
        }
    }

    private IEnumerator ChangeVolume(float step, float target)
    {
        while (Mathf.Abs(_soundSigaling.volume - target) > Mathf.Epsilon)
        {
            _soundSigaling.volume = Mathf.MoveTowards(_soundSigaling.volume, target, step * Time.deltaTime);

            yield return null;
        }
    }
}
