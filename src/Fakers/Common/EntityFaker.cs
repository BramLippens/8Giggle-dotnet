namespace Fakers.Common;

public class EntityFaker<TEntity>: Faker<TEntity> where TEntity : Entity
{
    protected EntityFaker() : base()
    {
        RuleFor(e => e.Id, f => f.Random.Guid());
    }
}