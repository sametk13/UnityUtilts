namespace SKUtils.Damageable
{
	public interface IDamageable
	{
		int Health { get; set; }

		void TakeDamage(int _damage);
	}
}