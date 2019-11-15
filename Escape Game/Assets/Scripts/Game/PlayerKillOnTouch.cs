using UnityEngine;

namespace Assets.Scripts.Game
{
    class PlayerKillOnTouch : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision) => this.CheckDoDamage(collision.collider);
        private void OnTriggerEnter(Collider other) => this.CheckDoDamage(other);

        private void CheckDoDamage(Collider other)
        {
            Player p = other.GetComponent<Player>();
            if (p == null)
                return;
            HealthSystem hs = p.GetComponent<HealthSystem>();
            hs.Damage(hs.MaxHealth);
        }
    }
}
