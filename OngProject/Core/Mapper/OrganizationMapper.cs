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
        public static OrganizationDto ToNewsDto(Organization org)
        {
            var organization = new OrganizationDto
            {
                Name = org.Name,
                Image = org.Image,
                Address = org.Address,
                Phone = org.Phone,
                WelcomeText = org.WelcomeText,
                AboutUsText = org.AboutUsText,
                LinkedinUrl = org.LinkedinUrl,
                FacebookUrl = org.FacebookUrl,
                InstagramUrl = org.InstagramUrl
            };

            return organization;
        }
        public static Organization ToOrganizationModel(OrganizationDto orgdto)
        {
            var model = new Organization
            {
                Name = orgdto.Name,
                Image = orgdto.Image,
                Address = orgdto.Address,
                Phone = orgdto.Phone,
                WelcomeText = orgdto.WelcomeText,
                AboutUsText = orgdto.AboutUsText,
                LinkedinUrl = orgdto.LinkedinUrl,
                FacebookUrl = orgdto.FacebookUrl,
                InstagramUrl = orgdto.InstagramUrl
            };
            return model;
        }
        public static Organization InsertToModel(InsertOrganizationDto orgdto)
        {
            var model = new Organization
            {
                Name = orgdto.Name,
                Image = orgdto.Image,
                Address = orgdto.Address,
                Phone = orgdto.Phone,
                WelcomeText = orgdto.WelcomeText,
                AboutUsText = orgdto.AboutUsText,
                LinkedinUrl = orgdto.LinkedinUrl,
                FacebookUrl = orgdto.FacebookUrl,
                InstagramUrl = orgdto.InstagramUrl
            };
            return model;
        }
    }
}
