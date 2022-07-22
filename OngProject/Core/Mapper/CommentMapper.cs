using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public static class CommentMapper
    {
        public static Comment ToComment(InsertCommentDto commentDto)
        {
            if (commentDto != null)
            {
                Comment comment = new()
                {
                    NewsID = commentDto.NewsID,
                    UserId = commentDto.UserID,
                    Body = commentDto.Body
                };
                return comment;
            }
            return null;
        }

        public static List<Comment> ToCommentsList(List<InsertCommentDto> commentDtos)
        {
            List<Comment> comments = new();

            if (commentDtos != null)
            {
                foreach (var c in commentDtos)
                {
                    comments.Add
                    (
                        new Comment
                        {
                            NewsID = c.NewsID,
                            UserId = c.UserID,
                            Body = c.Body
                        }
                    );
                }
                return comments;
            }
            return null;
        }

        public static CommentDto CommentDto(this Comment entity)
        {
            if (entity != null)
            {
                CommentDto comment = new()
                {
                    Body = entity.Body,
                    News = entity.News.Name,
                    User = entity.UserId
                };
                return comment;
            }
            return null;
        }

        public static List<GetCommentDto> ToOrderedDtoList(List<Comment> commentList)
        {
            List<GetCommentDto> commentDtoList = new();

            if (commentList != null)
            {
                foreach (var c in commentList)
                {
                    commentDtoList.Add(new GetCommentDto
                    {
                        Body = c.Body,
                    });
                }
                return commentDtoList;
            }
            return null;
        }

        public static Comment ToDtoComment(UpdateCommentDto commentDto, Comment comment)
        {
            if(comment != null)
            {
                comment.UserId = commentDto.UserId;
                comment.Body = commentDto.Body;
                return comment;
            }
            return null;
        }
    }
}
