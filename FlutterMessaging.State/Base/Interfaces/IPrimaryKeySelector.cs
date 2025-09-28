using System.Linq.Expressions;

namespace FlutterMessaging.State.Base.Interfaces
{
    public interface IPrimaryKeySelector<T> where T : class
    {
        static abstract Expression<Func<T, Guid>> PrimaryKey { get; }
    }

}
