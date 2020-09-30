using System.Collections.Generic;
using System.Linq; //TODO remove linq
using UnityEngine;
using Random = System.Random;

namespace ChinchetaGames
{
    public class AudioManager : Singleton<AudioManager>
    {
        void Start()
        {
            float audioVolume = PlayerPrefs.GetInt(k_musicVolume, 1) == 0 ? 0 : 1;
            float sfxVolume = PlayerPrefs.GetInt(k_sfxVolume, 1) == 0 ? 0 : 1;

            SetAudioVolume(audioVolume);
            SetSfxVolume(sfxVolume);

            m_randomGenerator = new Random();
        }

        public void PlayAudio(string name, bool loop)
        {
            m_audioSource.Stop();

            AudioClip file = m_audios.Where(x => x.name == name).SingleOrDefault();

            if (file != null)
            {
                m_audioSource.loop = loop;
                m_audioSource.clip = file;
                m_audioSource.Play();
            }
        }

        public void PlaySFX(SFXType type, bool force = false)
        {
            AudioClip clip = null;

            switch (type)
            {
                case SFXType.SXFGroup1:
                    clip = m_sfxGroup1[m_randomGenerator.Next(0, m_sfxGroup1.Count - 1)];
                    break;
                case SFXType.SXFGroup2:
                    clip = m_sfxGroup2[m_randomGenerator.Next(0, m_sfxGroup2.Count - 1)];
                    break;
                case SFXType.SXFGroup3:
                    clip = m_sfxGroup3[m_randomGenerator.Next(0, m_sfxGroup3.Count - 1)];
                    break;
                default:
                    break;
            }

            PlaySFX(clip, force);
        }

        public void PlaySFX(string name, bool force = false)
        {
            AudioClip clip = m_sfxs.Where(x => x.name == name).SingleOrDefault();

            PlaySFX(clip, force);
        }

        public void PlaySFX(AudioClip clip, bool force = false)
        {
            if (m_sfxSource.isPlaying && !force)
            {
                return;
            }

            if (clip != null)
            {
                m_sfxSource.clip = clip;
                m_sfxSource.Play();
            }
        }

        public void SetAudioVolume(float volume)
        {
            if (m_audioSource != null)
            {
                m_audioSource.volume = volume;
            }
        }

        public void SetSfxVolume(float volume)
        {
            if (m_sfxSource != null)
            {
                m_sfxSource.volume = volume;
            }
        }

        public enum SFXType
        {
            SXFGroup1,
            SXFGroup2,
            SXFGroup3
        }

        private const string k_musicVolume = "MusicVolume";
        private const string k_sfxVolume = "SFXVolume";

        private Random m_randomGenerator;

        [SerializeField]
        private bool m_enabled = false;
        [SerializeField]
        private AudioSource m_audioSource = default;
        [SerializeField]
        private AudioSource m_sfxSource = default;

        [SerializeField]
        private List<AudioClip> m_sfxs = default;
        [SerializeField]
        private List<AudioClip> m_audios = default;

        [SerializeField]
        private List<AudioClip> m_sfxGroup1 = default;
        [SerializeField]
        private List<AudioClip> m_sfxGroup2 = default;
        [SerializeField]
        private List<AudioClip> m_sfxGroup3 = default;
    }
}