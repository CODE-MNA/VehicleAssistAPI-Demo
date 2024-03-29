﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleAssist.Domain.Company;

namespace VehicleAssist.Domain.Service
{
    public class ServiceType:BaseEntity
    {
        public string ServiceTypeCode { get; set; }
        
        public string Description { get; set; }

        public List<CompanyService> CompanyServices { get; set; }

    }
}
