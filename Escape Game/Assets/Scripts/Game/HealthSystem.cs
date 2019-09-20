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
            private set => this._currentHealth = Mathf.Clamp(value, 0, MaxHealth);
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
            if (damage < 0)
                throw new NegativeInputException($"Damage does not take a negative input ({damage})");
            CurrentHealth -= damage;
        }
        public void Heal(int heal)
        {
            if (heal < 0)
                throw new NegativeInputException($"Heal does not take a negative input ({heal})");
            CurrentHealth += heal;
        }

        public void SetMaxHealth(int newValue)
        {
            if (newValue < 1)
                throw new System.ArgumentException($"Max health must be at least 1 ({newValue})");
            this.MaxHealth = newValue;
        }
    }
}
