﻿using System;
using System.Collections.Generic;
using System.Text;
using SmartLiving.Domain.DataTransferObjects;

namespace SmartLiving.Domain.Supervisors.Interfaces
{
    public partial interface ISupervisor
    {
        IEnumerable<DeviceGetDto> GetAllDevices(string userId);
        DeviceGetDto GetDeviceById(int id, string userId);
        DeviceGetDto CreateDevice(DeviceGetDto newModel, string userId);
        bool UpdateDevice(DeviceGetDto updateModel, string userId);
        bool DeleteDevice(int id, string userId);
    }
}
