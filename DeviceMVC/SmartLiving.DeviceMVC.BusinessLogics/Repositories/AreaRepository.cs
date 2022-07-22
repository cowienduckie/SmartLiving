﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SmartLiving.DeviceMVC.BusinessLogics.Configs;
using SmartLiving.DeviceMVC.BusinessLogics.Repositories.Interfaces;
using SmartLiving.DeviceMVC.Data.Models;

namespace SmartLiving.DeviceMVC.BusinessLogics.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        public IEnumerable<AreaModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AreaModel GetById(int id)
        {
            var client = new RestClient(ConnectConfigs.Url + $"/api/Sync/GetAreaById/{id}");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (!response.IsSuccessful) return null;
            var content = JsonConvert.DeserializeObject<JToken>(response.Content);

            return content?.ToObject<AreaModel>();
        }
    }
}