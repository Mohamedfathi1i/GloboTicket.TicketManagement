using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCatergoriesListWithEvents
{
    public class GetCateriesListWithEventsQuery:IRequest<List<CategoryEventListVm>>
    {
        public bool IncludeHistory { get; set; }
    }
}
