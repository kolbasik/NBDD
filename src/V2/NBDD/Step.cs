using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NBDD.V2
{
    [DebuggerStepThrough, DebuggerNonUserCode]
    internal abstract class Unit
    {
        protected Unit(Func<Task> action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            Action = action;
        }

        public Func<Task> Action { get; }
    }

    [DebuggerStepThrough, DebuggerNonUserCode]
    [DebuggerDisplay("Bind")]
    internal class Bind : Unit
    {
        public Bind(Func<Task> action) : base(action)
        {
        }
    }

    [DebuggerStepThrough, DebuggerNonUserCode]
    [DebuggerDisplay("Step: {Title}")]
    internal sealed class Step : Unit
    {
        public Step(string title, Func<Task> action) : base(action)
        {
            if (title == null) throw new ArgumentNullException(nameof(title));
            Title = title;
        }

        public string Title { get; }
    }
}