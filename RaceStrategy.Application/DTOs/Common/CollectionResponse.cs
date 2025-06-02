namespace RaceStrategy.Application.DTOs.Common
{
    public class CollectionResponse<TEntity> : ResponseBase
    {
        public ICollection<TEntity> EntityCollection { get; set; }
    }
}
