namespace DefaultNamespace.data.local.staticlao
{
    public interface StaticLao<T>
    {
        public void save(T value);
        public T fetchOrNull();
        public void remove();
    }
}