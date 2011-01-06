namespace MyBlog.Models
{
    public interface IBlogDataContext
    {
        System.Data.Linq.Table<Comment> Comments { get; }
        System.Data.Linq.Table<Post> Posts { get; }
        System.Data.Linq.Table<Category> Categories { get; }
        void SubmitChanges();
    }
}