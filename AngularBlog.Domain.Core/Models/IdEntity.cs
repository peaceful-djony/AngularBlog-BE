namespace AngularBlog.Domain.Models
{
    public abstract class IdEntity<T>
    {
        public T Id { get; set; }
    }
}