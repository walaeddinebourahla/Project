﻿namespace Shared.DataTransferObjects;

public class ArticleDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
