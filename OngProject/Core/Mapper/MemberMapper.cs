using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class MemberMapper
    {
        public static List<Member> ToMemberList(List<InsertMemberDto> memberDtos)
        {
            List<Member> members = new();

            if (memberDtos != null)
            {
                foreach (var m in memberDtos)
                {
                    members.Add
                    (
                        new Member
                        {
                            Description = m.Description,
                            Name = m.Name,
                            Image = m.Image,
                            LinkedinUrl = m.LinkedinUrl,
                            FacebookUrl = m.FacebookUrl,
                            InstagramUrl = m.InstagramUrl
                        }
                    );
                }
                return members;
            }
            return null;
        }

        public static List<MemberDto> ToMembersDtoList(List<Member> members)
        {
            List<MemberDto> memberDtos = new();

            if(members != null)
            {
                foreach (var m in members)
                {
                    memberDtos.Add
                    (
                        new MemberDto
                        {
                            Description = m.Description,
                            Name = m.Name,
                            Image = m.Image,
                            LinkedinUrl = m.LinkedinUrl,
                            FacebookUrl = m.FacebookUrl,
                            InstagramUrl = m.InstagramUrl
                        }
                    );
                }
                return memberDtos;
            }
            return null;
        }

        public static Member UpdateToMember(UpdateMemberDto memberDto)
        {
            if (memberDto != null)
            {
                Member member = new()
                {
                    Name = memberDto.Name,
                    Description = memberDto.Description,
                    Image = memberDto.Image,
                    FacebookUrl = memberDto.FacebookUrl,
                    InstagramUrl = memberDto.InstagramUrl,
                    LinkedinUrl = memberDto.LinkedinUrl
                };
                return member;
            }
            return null;
        }
    }
}
