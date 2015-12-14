﻿namespace ForumSystem.Api.Models.Posts
{
    using ForumSystem.Api.Models.Contracts;
    using ForumSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using AutoMapper;

    public class PostsResponseModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public DateTime PostDate { get; set; }

        public string Content { get; set; }

        public string NickName { get; set; }

        public string ThreadTitle { get; set; }

        public IList<CommentDataModel> Comments { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Post, PostsResponseModel>()
                .ForMember(prs => prs.NickName, opts => opts.MapFrom(p => p.User.Nickname));

            config.CreateMap<Post, PostsResponseModel>()
                .ForMember(prs => prs.ThreadTitle, opts => opts.MapFrom(p => p.Thread.Title));
        }
    }
}