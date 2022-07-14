using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public static class CommentMapper
    {
        public static Comment ToComment(InsertCommentDto commentDto)
        {
            Comment comment = new()
            {
                NewsID = commentDto.NewsID,
                UserId = commentDto.UserID,
                Body = commentDto.Body 
            };
            return comment;
        }
        public static List<Comment> ToCommentsList(List<InsertCommentDto> commentDtos)
        {
            List<Comment> comments = new();
            foreach (var c in commentDtos)
            {
                comments.Add(
                    new Comment
                    {
                        NewsID = c.NewsID,
                        UserId=c.UserID,
                        Body=c.Body
                    }
                    );
            }
            return comments;
        }
        public static CommentDto CommentDto(this Comment entity)
        {
            return new CommentDto
            {
                Body = entity.Body,
                News = entity.News.Name,
                User = entity.UserId
            };
        }

        public static List<GetCommentDto> ToOrderedDtoList(List<Comment> commentList)
        {
            List<GetCommentDto> commentDtoList = new();
            foreach(var c in commentList)
            {
                commentDtoList.Add(new GetCommentDto
                {
                    Body = c.Body,
                });
            }
            return commentDtoList;
        }

        public static Comment ToDtoComment(UpdateCommentDto commentDto, Comment comment)
        {
            comment.UserId = commentDto.UserId;
            comment.Body = commentDto.Body;
            return comment;
        }

    }
}
