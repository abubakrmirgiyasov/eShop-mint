﻿using AutoMapper;
using Mint.Domain.Common;
using Mint.Infrastructure.Redis.Interface;
using Mint.WebApp.Admin.DTO_s;
using Mint.WebApp.Admin.Repositories;
using Mint.WebApp.Admin.Repositories.Interfaces;

namespace Mint.WebApp.Admin.Services;

public class TagService(
    IMapper mapper,
    IDistributedCacheManager cacheManager, 
    ITagRepository tagRepository, 
    ILogger<TagService> logger)
{
    private readonly IMapper _mapper = mapper;
    private readonly IDistributedCacheManager _cacheManager = cacheManager;
    private readonly ITagRepository _tagRepository = tagRepository;
    private readonly ILogger<TagService> _logger = logger;

    public async Task<IEnumerable<TagFullViewModel>> GetTagsAsync()
    {
        try
        {
            var tags = _cacheManager.Get<IEnumerable<TagFullViewModel>>(Constants.REDIS_SAMPLE_TAGS);
            
            if (tags is null)
            {
                var tagsRepository = await _tagRepository.GetTagsAsync();
                _cacheManager.Set(
                    key: Constants.REDIS_SAMPLE_TAGS,
                    value: tagsRepository);
                return tagsRepository;
            }

            return tags;
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<TagFullViewModel> GetTagByIdAsync(Guid id)
    {
        try
        {
            var tag = await _tagRepository.GetTagByIdAsync(id);
            return tag;
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task AddNewTagAsync(TagFullBindingModel model)
    {
        try
        {
            await _tagRepository.NewTagAsync(model);

            var tags = _cacheManager
                .Get<IEnumerable<TagFullViewModel>>(Constants.REDIS_SAMPLE_TAGS)
                .ToList();

            tags?.Add(_mapper.Map<TagFullViewModel>(model));

            _cacheManager.Set(
                key: Constants.REDIS_SAMPLE_TAGS,
                value: tags);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task UpdateTagAsync(TagFullBindingModel model)
    {
        try
        {
            await _tagRepository.UpdateTagAsync(model);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task DeleteTagAsync(Guid id)
    {
        try
        {
            await _tagRepository.DeleteTagAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }
}