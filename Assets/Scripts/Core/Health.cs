using UnityEngine;

namespace RPG.Core
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
                Die();
            }
        }

        private void Die()
        {
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();

        }
    }
}