﻿namespace MTKDotNetCore.EFCoreRestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly AppDbContext _context;

    public BlogController()
    {
        _context = new AppDbContext();
    }

    #region Read

    [HttpGet]
    public IActionResult Read()
    {
        var lst = _context.Blogs.ToList();
        return Ok(lst);
    }
    #endregion

    #region Edit

    [HttpGet("{id}")]
    public IActionResult Edit(int id)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return NotFound("No Data Found");
        }
        return Ok(item);
    }
    #endregion

    #region Create

    [HttpPost]
    public IActionResult Create(BlogModel blog)
    {
        _context.Blogs.Add(blog);
        var result = _context.SaveChanges();
        string message = result > 0 ? "Creating Successful" : "Creating Fail";
        return Ok(message);
    }

    #endregion

    #region Update

    [HttpPut("{id}")]
    public IActionResult Update(int id, BlogModel blog)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return NotFound("No Data Found");
        }
        item.BlogTitle = blog.BlogTitle;
        item.BlogAuthor = blog.BlogAuthor;
        item.BlogContent = blog.BlogContent;

        var result = _context.SaveChanges();
        string message = result > 0 ? "Updating Successful" : "Updating Fail";
        return Ok(message);
    }
    #endregion

    #region Patch

    [HttpPatch("{id}")]
    public IActionResult Patch(int id, BlogModel blog)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return NotFound("No Data Found");
        }
        if (!string.IsNullOrEmpty(blog.BlogTitle))
            item.BlogTitle = blog.BlogTitle;
        if (!string.IsNullOrEmpty(blog.BlogAuthor))
            item.BlogAuthor = blog.BlogAuthor;
        if (!string.IsNullOrEmpty(blog.BlogContent))
            item.BlogContent = blog.BlogContent;

        var result = _context.SaveChanges();
        string message = result > 0 ? "Updating Successful" : "Updating Fail";
        return Ok(message);
    }
    #endregion

    #region Delete

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
        if (item is null)
        {
            return NotFound("No Data Found");
        }
        _context.Blogs.Remove(item);
        var result = _context.SaveChanges();
        string message = result > 0 ? "Deleting Successful" : "Deleting Fail";
        return Ok(message);
    }
    #endregion
}
