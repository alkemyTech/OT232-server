using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class CommentMapper
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
    }
}
