using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.ComponentModel.Design;

namespace Service;

internal sealed class ArticleService : IArticleService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public ArticleService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ArticleDto>> GetArticles(Guid journalId, bool trackChanges)
    {
        var journal = await _repository.Journal.GetJournal(journalId, trackChanges);
        if (journal is null)
            throw new JournalNotFoundException(journalId);

        var articles = await _repository.Article.GetArticles(journalId, trackChanges);
        var articlesDto = _mapper.Map<IEnumerable<ArticleDto>>(articles);

        return articlesDto;
    }

    public async Task<ArticleDto> GetArticle(Guid journalId, Guid articleId, bool trackChanges)
    {
        var journal = await _repository.Journal.GetJournal(journalId, trackChanges);
        if (journal is null)
            throw new JournalNotFoundException(journalId);

        var article = await _repository.Article.GetArticle(journalId, articleId, trackChanges);
        if (article is null)
            throw new ArticleNotFoundException(articleId);

        var articleDto = _mapper.Map<ArticleDto>(article);
        return articleDto;
    }

    public async Task<ArticleDto> CreateArticle(Guid journalId, ArticleForCreationDto articleForCreation, bool trackChanges)
    {
        var journal = await _repository.Journal.GetJournal(journalId, trackChanges);
        if (journal is null)
            throw new JournalNotFoundException(journalId);

        var articleEntity = _mapper.Map<Article>(articleForCreation);
        _repository.Article.CreateArticle(journalId, articleEntity);
        await _repository.SaveAsync();

        var articleToReturn = _mapper.Map<ArticleDto>(articleEntity);
        return articleToReturn;
    }

    public async Task DeleteArticle(Guid journalId, Guid articleId, bool trackChanges)
    {
        var journal = await _repository.Journal.GetJournal(journalId, trackChanges);
        if (journal is null)
            throw new JournalNotFoundException(journalId);

        var article = await _repository.Article.GetArticle(journalId, articleId, trackChanges);
        if (article is null)
            throw new ArticleNotFoundException(articleId);

        _repository.Article.DeleteArticle(article);
        await _repository.SaveAsync();
    }

    public async Task UpdateArticle(Guid journalId, Guid articleId,ArticleForUpdateDto articleForUpdate, bool journalTrackChanges, bool articleTrackChanges)
    {
        var journal = await _repository.Journal.GetJournal(journalId, journalTrackChanges);
        if (journal is null)
            throw new JournalNotFoundException(journalId);

        var articleEntity = await _repository.Article.GetArticle(journalId, articleId, articleTrackChanges);
        if (articleEntity is null)
            throw new ArticleNotFoundException(articleId);

        _mapper.Map(articleForUpdate, articleEntity);
        await _repository.SaveAsync();
    }
}
