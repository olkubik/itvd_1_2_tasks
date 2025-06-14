public class Archer : Character
{
    private int arrows;

    public Archer(string name) : base(name, 50)
    {
        arrows = 10;
    }

    public override (int damage, string message) Attack()
    {
        if (!CanAttack())
            return (0, $"{Name} не может атаковать: закончились стрелы!");
        arrows--;
        int damage = random.Next(15, 21);
        return (damage, $"{Name} выстрелил из лука, нанеся {damage} урона!");
    }

    public override bool CanAttack()
    {
        return arrows > 0;
    }

    public override void RestoreResource()
    {
        arrows += 5;
    }
}
