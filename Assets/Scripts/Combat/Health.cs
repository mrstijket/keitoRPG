using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [HideInInspector] public bool isDead = false;
        [SerializeField] float healthPoints = 100f;

        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            if(healthPoints == 0 && !isDead)
            {
                isDead = true;
                GetComponent<Animator>().SetTrigger("die");
            }
        }
    }
}