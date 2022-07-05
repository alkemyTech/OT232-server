using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class OrganizationMapper
    {
        public static List<OrganizationDto> ToOrganizationsDtoList(List<Organization> organizations)
        {
            List<OrganizationDto> organizationDtos = new();

            foreach (var m in organizations)
            {
                organizationDtos.Add
                (
                    new OrganizationDto
                    {

                        Name = m.Name,
                        Image = m.Image,
                        Address = m.Address,
                        Phone = m.Phone,
                        WelcomeText = m.WelcomeText,
                        AboutUsText = m.AboutUsText,
                        LinkedinUrl = m.LinkedinUrl,
                        FacebookUrl = m.FacebookUrl,
                        InstagramUrl = m.InstagramUrl
                    }
                );
            }

            return organizationDtos;
        }
    }
}
