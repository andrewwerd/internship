namespace Domain
{
    public abstract class Entity<T>
    {
        public T Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
