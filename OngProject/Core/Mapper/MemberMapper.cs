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

        public static List<MemberDto> ToMembersDtoList(List<Member> members)
        {
            List<MemberDto> memberDtos = new();

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
        public static Member UpdateToMember(UpdateMemberDto memberDto)
        {
            if (memberDto != null)
            {
                Member member = new Member();

                member.Name = memberDto.Name;
                member.Description = memberDto.Description;
                member.Image = memberDto.Image;
                member.FacebookUrl = memberDto.FacebookUrl;
                member.InstagramUrl = memberDto.InstagramUrl;
                member.LinkedinUrl = memberDto.LinkedinUrl;


                return member;

            }
            return null;
                
        }

    }
}
