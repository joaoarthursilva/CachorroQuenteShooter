using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;

        [SerializeField] private AudioMixerGroup audioMixerGroup;

        private void Awake()
        {
            foreach (var sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.outputAudioMixerGroup = audioMixerGroup;
                // sound.source.pitch = sound.pitch;
            }
        }

        public void Play(string soundName)
        {
            var s = Array.Find(sounds, sound => sound.name == soundName);
            s.source.Play();
        }
    }
}