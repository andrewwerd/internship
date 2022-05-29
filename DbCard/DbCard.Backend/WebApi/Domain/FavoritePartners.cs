namespace Domain
{
    public class FavoritePartners : Entity<long>
    {
        public long CustomerId { get; set; }
        public long? PartnerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Partner Partner { get; set; }
    }
}
