﻿namespace ForumSystem.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using ForumSystem.Api.Models.Posts;
    //using io.iron.ironmq;
    using ForumSystem.Services.Contracts;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;
    using System.Web.Http.Cors;

    [EnableCors("*", "*", "*")]
    public class PostsController : ApiController
    {
        private const string InvalidData = "Incorrect post data";

        private IPostsService postsService;

        public PostsController(IPostsService service)
        {
            this.postsService = service;
        }

        //api/posts/1
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var post = this.postsService
                .GetById(id);

            if (post == null)
            {
                return this.NotFound();
            }

            var responsePost = Mapper.Map<PostsResponseModel>(post);

            return this.Ok(responsePost);
        }

        //api/posts?threadId=1
        [HttpGet]
        public IHttpActionResult GetByThread(int threadId)
        {
            var posts = this.postsService
                .GetByThread(threadId)
                .ProjectTo<PostsResponseModel>()
                .ToList();

            return this.Ok(posts);
        }

        //api/posts
        [Authorize]
        [HttpGet]
        public IHttpActionResult GetByUser()
        {
            var user = this.User.Identity.Name;

            var posts = this.postsService
                .GetByUser(user)
                .ProjectTo<PostsResponseModel>()
                .ToList();

            return this.Ok(posts);
        }

        //api/posts?threadId=1
        [Authorize]
        [HttpPost]
        public IHttpActionResult Add(int threadId, PostsRequestModel post)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(InvalidData);
            }

            string userName = this.User.Identity.Name;
            int postId;
            try
            {
                postId = this.postsService
                     .Add(post.Content, threadId, userName);
            }
            catch (ArgumentException ae)
            {
                return this.BadRequest(ae.Message);
            }

            return this.Ok("Post " + postId + " added");
        }

        //api/posts/1
        [Authorize]
        [HttpPut]
        public IHttpActionResult Update(int id, PostsRequestModel post)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(InvalidData);
            }

            try
            {
                this.postsService.Update(id, post.Content);
            }
            catch (ArgumentException ae)
            {
                return this.BadRequest(ae.Message);
            }

            return this.Ok();
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            string userName = this.User.Identity.Name;

            try
            {
                this.postsService.Delete(id, userName);
            }
            catch (ArgumentException ex)
            {
                return this.BadRequest(ex.Message);
            }
            catch
            {
                return this.BadRequest("Post can not be deleted");
            }

            return this.Ok();
        }
    }
}