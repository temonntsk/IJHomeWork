using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private Detector _detector;
    [SerializeField] private AudioSource _soundSigaling;
    [SerializeField] private float _volumeStep;

    private float _increase = 1;
    private float _decrease = 0;
    private float _volumeZero = 0;
    private Coroutine _changeVolumeSound;

    private void OnEnable()
    {
        _detector.Reached += Play;
    }

    private void OnDisable()
    {
        _detector.Reached -= Play;
    }

    public void Play(bool isPlaying)
    {
        if (isPlaying)
            SignalingStart();
        else
            SignalingStop();
    }

    public void SignalingStart()
    {
        StopCoroutineChangeVolume();

        _soundSigaling.volume = _volumeZero;
        _soundSigaling.Play();
        _changeVolumeSound = StartCoroutine(ChangeVolume(_volumeStep, _increase));
    }

    public void SignalingStop()
    {
        StopCoroutineChangeVolume();

        _changeVolumeSound = StartCoroutine(ChangeVolume(_volumeStep, _decrease));

        if (_soundSigaling.volume == _volumeZero)
            _soundSigaling.Stop();
    }

    private void StopCoroutineChangeVolume()
    {
        if (_changeVolumeSound != null)
            StopCoroutine(_changeVolumeSound);
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
