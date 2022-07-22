using Newtonsoft.Json;
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

            if (organizations != null)
            {
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
            return null;
        }

        public static Organization ToOrganizationModel(OrganizationDto orgdto)
        {
            if (orgdto != null) 
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
            return null;
        }

        public static Organization UpdateToModel(UpdateOrganizationDto orgdto)
        {
            if(orgdto != null)
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
            return null;
        }

        public static Organization MixModels(UpdateOrganizationDto dto, Organization org)
        {
            if (org != null)
            {
                org.Address = dto.Address;
                org.Image = dto.Image;
                org.Phone = dto.Phone;
                org.WelcomeText = dto.WelcomeText;
                org.AboutUsText = dto.AboutUsText;
                org.LinkedinUrl = dto.LinkedinUrl;
                org.FacebookUrl = dto.FacebookUrl;
                org.InstagramUrl = dto.InstagramUrl;
            }
            return org;
        }

        public static List<Organization> ToOrganizationList(List<InsertOrganizationDto> orgDtos)
        {
            List<Organization> organizations = new();

            if (orgDtos != null) 
            { 
                foreach (var m in orgDtos)
                {
                    organizations.Add
                    (
                        new Organization
                        {
                            Address = m.Address,
                            Image = m.Image,
                            Phone = m.Phone,
                            WelcomeText = m.WelcomeText,
                            AboutUsText = m.AboutUsText,
                            LinkedinUrl = m.LinkedinUrl,
                            FacebookUrl = m.FacebookUrl,
                            InstagramUrl = m.InstagramUrl
                        }
                    );
                }
                return organizations;
            }
            return null;
        }
    }
}

