using UnityEngine;
using UnityEngine.Playables;
namespace RPG.Cinematics
{
    public class CinematicTrigger : MonoBehaviour
    {
        bool isTriggered = false;
        private void OnTriggerEnter(Collider other)
        {
            if(!isTriggered && other.gameObject.tag == "Player")
            {
                GetComponent<PlayableDirector>().Play();
                isTriggered = true;
            }
        }
    }
}