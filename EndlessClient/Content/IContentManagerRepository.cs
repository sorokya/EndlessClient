﻿using AutomaticTypeMapper;
using Microsoft.Xna.Framework.Content;

namespace EndlessClient.Content
{
    public interface IContentManagerRepository
    {
        ContentManager Content { get; set; }
    }

    public interface IContentManagerProvider
    {
        ContentManager Content { get; }
    }

    [MappedType(BaseType = typeof(IContentManagerProvider), IsSingleton = true)]
    [MappedType(BaseType = typeof(IContentManagerRepository), IsSingleton = true)]
    public class ContentManagerRepository : IContentManagerRepository, IContentManagerProvider
    {
        public ContentManager Content { get; set; }
    }
}
