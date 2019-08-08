namespace NotTheHero.Models
{
    internal class Boss : Enemy
    {
        public Boss(Enemy enemy) : base(enemy.MaxHealth, enemy.Name + " Boss", enemy.Speed, enemy.Accuracy, enemy.Defense, enemy.Rank, enemy.Gold, enemy.Power)
        {
            isBoss = true;
            maxHealth = (int)System.Math.Truncate(maxHealth * 1.5);
            speed = (int)System.Math.Truncate(speed * 1.5);
            accuracy = (int)System.Math.Truncate(accuracy * 1.5);
            defense = (int)System.Math.Truncate(defense * 1.5);
            Gold = (int)System.Math.Truncate(Gold * 1.5);
            Power = (int)System.Math.Truncate(Power * 1.5);
            if (rank < MAX_RANK) rank++;
        }
    }
}
