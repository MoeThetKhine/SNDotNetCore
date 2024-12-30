namespace MTKDotNetCore.NLayerApi.Features.Blogs;

public class BlogController
{
    private readonly BL_Blog _bL_Blog;

    public BlogController()
    {
        _bL_Blog = new BL_Blog();
    }

    #region Read

    [HttpGet]
    public IActionResult Read()
    {
        var lst = _bL_Blog.GetBlogs();
        return Ok(lst);
    }

    #endregion

    [HttpGet("{id}")]
    public IActionResult Edit(int id)
    {
        var item = _bL_Blog.GetBlog(id);
        if(item is null)
        {
            return NotFound("No data found");
        }
        return Ok(item);
    }
    [HttpPost]
    public IActionResult CreateBlog(BlogModel blog)
    {
        var result = _bL_Blog.CreateBlog(blog);
        string 
    } 
}
