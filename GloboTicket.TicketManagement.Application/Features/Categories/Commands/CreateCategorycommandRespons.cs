﻿using GloboTicket.TicketManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategorycommandRespons: BaseResponse
    {
        public CreateCategorycommandRespons(): base()
        {
            
        }

        public CreateCategoryDto Category { get; set; } = default!;
    }
}
