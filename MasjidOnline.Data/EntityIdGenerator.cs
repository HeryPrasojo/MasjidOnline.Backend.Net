﻿using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Data;

public class EntityIdGenerator() : IEntityIdGenerator
{
    public async Task InitializeAsync(IDataAccess dataAccess)
    {
        _captchaQuestionId = await dataAccess.CaptchaQuestionRepository.GetMaxIdAsync();
    }

    private long _captchaQuestionId;
    public long CaptchaQuestionId => Interlocked.Increment(ref _captchaQuestionId);


}
