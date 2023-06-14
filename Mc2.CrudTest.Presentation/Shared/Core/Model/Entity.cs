namespace Mc2.CrudTest.Presentation.Shared.Core.Model;

public abstract record Entity<T> : IEntity<T>
{
    public T Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public long? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public long? LastModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
}
