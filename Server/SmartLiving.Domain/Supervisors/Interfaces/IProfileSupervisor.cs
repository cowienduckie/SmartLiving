﻿using SmartLiving.Domain.DataTransferObjects;
using System.Collections.Generic;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<ProfileGetDto> GetAllProfiles(string userId);

        ProfileGetDto GetProfileById(int id, string userId);

        ProfileGetDto CreateProfile(ProfileGetDto newModel, string userId);

        bool UpdateProfile(ProfileGetDto updateModel, string userId);

        bool DeleteProfile(int id, string userId);
    }
}