﻿namespace ForumSystem.Api.Models
{
    using AutoMapper;
    using ForumSystem.Api.Models.Contracts;
    using ForumSystem.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    public class CommentDataModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public static Expression<Func<Comment, CommentDataModel>> FromComment
        {
            get
            {
                return c => new CommentDataModel
                {
                    UserName = c.User.UserName,
                    Content = c.Content,
                    CommentDate = c.CommentDate,
                    Id = c.Id
                };
            }
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public DateTime CommentDate { get; set; }

        public string Content { get; set; }

        [Required]
        public int PostId { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Comment, CommentDataModel>()
                .ForMember(cdm => cdm.UserName, opts => opts.MapFrom(c => c.User.UserName));
        }
    }
}