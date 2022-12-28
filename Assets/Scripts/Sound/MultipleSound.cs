using UnityEngine;

namespace RPG.Sound
{
    public class MultipleSound : MonoBehaviour
    {
        AudioSource audioSource;
        [SerializeField] AudioClip[] audioClips;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }
        public void UpdateClip()
        {
            int number = Random.Range(1, audioClips.Length);
            audioSource.clip = audioClips[number];
            audioSource.Play();
        }
    }
}