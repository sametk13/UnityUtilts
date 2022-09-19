using UnityEngine;
using UnityEngine.Events;


namespace SKUtils.Damageable
{
    public abstract class PlayerBase : MonoBehaviour, IDamageable
    {
        public UnityEvent OnDamaged;
        public UnityEvent OnDied;
        public UnityEvent OnAttacked;

        private int _health;
        public int Health { get { return _health; } set { _health = value; } }


        [SerializeField] int _maxHealth;
        public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }


        [SerializeField] private int _damage;
        public int Damage { get { return _damage; } set { _damage = value; } }


        private void Awake()
        {
            _health = MaxHealth;
        }

        public void TakeDamage(int _damage)
        {
            OnDamaged?.Invoke();

            DecreaseHealth(_damage);

            Debug.Log("Player base class : TakeDamage method called!");
        }

        protected virtual void Attack(IDamageable damageable)
        {
            OnAttacked?.Invoke();
            damageable.TakeDamage(Damage);
            Debug.Log("Player base class : Attack method called!");
        }

        protected virtual void Die()
        {
            OnDied?.Invoke();
            Debug.Log("Player base class : Die method called!");
            Health = 0;
        }

        protected virtual void IncreaseHealth(int _value)
        {
            if (_health + _value < MaxHealth)
            {
                _health += _value;
            }
            else
            {
                _health = MaxHealth;
            }
        }
        protected virtual void DecreaseHealth(int _value)
        {
            if (_health - _value > 0)
            {
                _health -= _value;
            }
            else
            {
                _health = 0;
                Die();
            }
        }
    }
}