namespace Fakers.Common;

public class EntityFaker<TEntity>: Faker<TEntity> where TEntity : Entity
{
    protected EntityFaker(string locale = "en") : base(locale)
    {
        RuleFor(e => e.Id, f => f.Random.Guid());
    }
}