using Assets.Scripts.Helpers;
using System;

namespace Assets.Scripts.Game
{
    public interface IHealthSystem
    {
        int CurrentHealth { get; }
        int MaxHealth { get; }
        void Damage(int damage);
        void Heal(int heal);
        void SetMaxHealth(int newValue);
    }
}