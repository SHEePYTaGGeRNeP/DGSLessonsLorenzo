using Assets.Scripts.Game;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.UI
{
    class DamageButton : MonoBehaviour
    {
        [SerializeField]
        private AnimationCurve _damageCurve;

        [SerializeField]
        private HealthSystem _target;

        public void DoDamage()
        {
            int damage = (int)_damageCurve.Evaluate(Random.Range(0, _damageCurve.keys.Last().time));
            Debug.Log("random damage: " + damage);
            this._target.Damage(damage);
        }
    }
}
