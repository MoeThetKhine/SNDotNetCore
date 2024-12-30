namespace MTKDotNetCore.NLayerApi.Features.Blogs;

public class BL_Blog
{
    private readonly DA_Blog _daBlog;

    public BL_Blog()
    {
        _daBlog = new DA_Blog();
    }

    #region GetBlogs

    public List<BlogModel> GetBlogs()
    {
        var lst = _daBlog.GetBlogs();
        return lst;
    }

    #endregion

    #region GetBlog

    public BlogModel GetBlog(int id)
    {
        var item = _daBlog.GetBlog(id);
        return item;
    }

    #endregion

    #region CreateBlog

    public int CreateBlog(BlogModel requestModel)
    {
        var result = _daBlog.CreateBlog(requestModel);
        return result;
    }

    #endregion

    #region UpdateBlog

    public int UpdateBlog(int id, BlogModel requestModel)
    {
        var result = _daBlog.UpdateBlog(id, requestModel);
        return result;
    }

    #endregion

    #region UpdateBlog

    public int DeleteBlog(int id)
    {
        var result = _daBlog.DeleteBlog(id);
        return result;
    }

    #endregion
}
