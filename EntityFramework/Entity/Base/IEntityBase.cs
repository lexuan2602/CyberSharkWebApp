namespace TEST_CRUD.EntityFramework.Entity.Base
{
    public interface IEntityBase
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }
    }
}
