using System;
using System.Reflection;

namespace Cart.Infrastructure
{

    [AttributeUsage(AttributeTargets.Field)]
    public class StateAttribute : Attribute
    {
        public Type StateType { get; }

        public StateAttribute(Type stateType)
        {
            StateType = stateType
                        ?? throw new ArgumentNullException(nameof(stateType));
        }
    }

    public abstract class State<T>
        where T : class
    {
        private protected T Entity { get; }

        protected State(T entity)
        {
            Entity = entity
                     ?? throw new ArgumentNullException(nameof(entity));
        }
    }

    public static class StateCodeExtensions
    {
        public static State<T> ToState<T>(this Enum stateCode, object entity)
            where T : class
            => (State<T>) Activator.CreateInstance(
                stateCode.GetType()
                    .GetCustomAttribute<StateAttribute>()
                    ?.StateType 
                ?? throw new NotSupportedException(), entity
            );
    }
    
}