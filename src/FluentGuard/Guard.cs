using System.Collections.Generic;

namespace FluentGuard
{
    public static class Guard
    {
        public static Guard<TInput> With<TInput>(TInput? input, string name)
        {
            return new Guard<TInput>(input, name);
        }
    }

    public class Guard<TInput> : IGuardClauseWithInput<TInput>
    {
        internal Guard(TInput? input, string name)
        {
            Input = input;
            Name = name;
        }

        public TInput? Input { get; }
        public string Name { get; }

        public bool HasFailed => Errors.Count > 0;
        public Errors Errors { get; } = new Errors();
    }
}
