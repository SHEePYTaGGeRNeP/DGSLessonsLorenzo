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
            IHealthSystem hs = p.GetComponent<IHealthSystem>();
            hs.Damage(hs.MaxHealth);
        }
    }
}
