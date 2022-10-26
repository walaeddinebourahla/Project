using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.ComponentModel.Design;

namespace API.Presentation.Controllers;

[Route("api/journals/{journalId}/articles")]
[ApiController]
public class ArticlesController : ControllerBase
{
    private readonly IServiceManager _service;

    public ArticlesController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetArticles(Guid journalId)
    {
        var articles = await _service.ArticleService.GetArticles(journalId, trackChanges: false);
        return Ok(articles);
    }


    [HttpGet("{articleId:guid}", Name = "GetArticleById")]
    public async Task<IActionResult> GetArticle(Guid journalId, Guid articleId)
    {
        var article = await _service.ArticleService.GetArticle(journalId, articleId, trackChanges: false);
        return Ok(article);
    }

    [HttpPost]
    public async Task<IActionResult> CreateArticle(Guid journalId, [FromBody] ArticleForCreationDto article)
    {
        if (article == null)
            return BadRequest("ArticleForCreationDto is null.");

        if (!ModelState.IsValid) 
            return UnprocessableEntity(ModelState);

        var articleToReturn = await _service.ArticleService.CreateArticle(journalId, article, trackChanges: false);

        return CreatedAtRoute("GetArticleById", new { journalId, articleId = articleToReturn.Id }, articleToReturn);
    }

    [HttpDelete("{articleId:guid}")]
    public async Task<IActionResult> DeleteArticle(Guid journalId, Guid articleId)
    {
        await _service.ArticleService.DeleteArticle(journalId, articleId, trackChanges: false);
        return NoContent();
    }

    [HttpPut("{articleId:guid}")]
    public async Task<IActionResult>  UpdateArticle(Guid journalId, Guid articleId, [FromBody] ArticleForUpdateDto article)
    {
        if (article is null)
            return BadRequest("ArticleForUpdateDto is null");

        if (!ModelState.IsValid) 
            return UnprocessableEntity(ModelState);

        await _service.ArticleService.UpdateArticle(journalId, articleId, article, journalTrackChanges: false, articleTrackChanges: true);

        return NoContent();
    }
}
