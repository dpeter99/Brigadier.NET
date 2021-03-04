using Brigadier.NET.Tree;

namespace Brigadier.NET.Builder
{
    public static class LiteralArgumentBuilderExtensions
    {
        // ReSharper disable once UnusedParameter.Global
        // context is used to infer generic parameters in API
        public static LiteralArgumentBuilder<TSource> Literal<TSource>(this IArgumentContext<TSource> context, string name, string desc = "")
        {
            return new LiteralArgumentBuilder<TSource>(name,desc);
        }
    }

    public class LiteralArgumentBuilder<TSource> : ArgumentBuilder<TSource, LiteralArgumentBuilder<TSource>, LiteralCommandNode<TSource>>
    {
        public LiteralArgumentBuilder(string literal, string desc = "")
        {
            Literal = literal;
            Description = desc;
        }

        public static LiteralArgumentBuilder<TSource> LiteralArgument(string name)
        {
            return new LiteralArgumentBuilder<TSource>(name);
        }

        public string Literal { get; }
        
        public string Description { get; }

        public override LiteralCommandNode<TSource> Build()
        {
            var result = new LiteralCommandNode<TSource>(Literal, Command, Requirement, RedirectTarget, RedirectModifier, IsFork,Description);
            
            foreach (var argument in Arguments)
            {
                result.AddChild(argument);
            }

            return result;
        }
    }
}