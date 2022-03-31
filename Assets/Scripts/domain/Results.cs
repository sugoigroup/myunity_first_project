using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.repository;

namespace DefaultNamespace.domain
{
    public interface IResults<out T, out S>
    {
        public T returnData();
        public S errorCode();

    }

    public class Results<T, S>
    {
        public IResults<T, S> results;
    }

    public class Success<T, S> : IResults<T, S>
    {
        public T value;

        public Success(T value)
        {
            this.value = value;
        }

        public T returnData()
        {
            return this.value;
        }

        public S errorCode()
        {
            return default(S);
        }
    }

    public class Failure<T, S> : IResults<T, S> 
    {
        public S cause;

        public Failure(S error)
        {
            this.cause = cause;
        }

        public T returnData()
        {
            return default(T);
        }

        public S errorCode()
        {
            return this.cause;
        }
    }
}