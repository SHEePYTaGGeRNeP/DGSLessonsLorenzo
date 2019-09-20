using UnityEngine;

namespace Assets.Scripts.Game
{
    public class HealthSystem : MonoBehaviour
    {

        [Header("DEBUG INFO")]
        [SerializeField]
        private int _maxHealth;
        public int MaxHealth
        {
            get => _maxHealth;
            private set
            {
                _maxHealth = value;
                if (CurrentHealth > _maxHealth)
                    CurrentHealth = _maxHealth;
            }
        }

        [SerializeField]
        private int _currentHealth;
        public int CurrentHealth
        {
            get => _currentHealth;
            private set
            {
                _currentHealth = Mathf.Min(value, MaxHealth);
            }
        }

        public static HealthSystem CreateHealthSystem(GameObject go, int maxHealth) => CreateHealthSystem(go, maxHealth, maxHealth);
        public static HealthSystem CreateHealthSystem(GameObject go, int maxHealth, int currentHealth)
        {
            HealthSystem hs = go.AddComponent<HealthSystem>();
            hs.MaxHealth = maxHealth;
            hs.CurrentHealth = currentHealth;
            return hs;
        }

        public void Damage(int damage)
        {
            CurrentHealth -= damage;
        }
        public void Heal(int heal)
        {
            CurrentHealth += heal;
        }
    }
}
