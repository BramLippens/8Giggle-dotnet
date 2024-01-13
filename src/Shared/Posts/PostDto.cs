using FluentValidation;

namespace Shared.Posts;

public static class PostDto
{
    public class Index
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
    }

    public class Detail: Index
    {
        public List<TagDto.Index>? TagList { get; set; }
    }

    public class Mutate
    {
        public string Title { get; set; }
        public List<TagDto.Index> TagList { get; set; }

        public class Validator : AbstractValidator<Mutate>
        {
            public Validator() 
            { 
                RuleFor(x => x.Title).NotEmpty().Length(1, 100);
                RuleForEach(x => x.TagList).NotNull().WithMessage("Tags cannot be empty");
            }
        }
    }
}

public static class TagDto
{
    public class Index
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}