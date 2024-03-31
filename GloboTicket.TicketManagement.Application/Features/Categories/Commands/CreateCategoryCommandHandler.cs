using AutoMapper;
using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategorycommandRespons>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRespository<Category> _categoryRepository;

        public CreateCategoryCommandHandler(IMapper mapper, IAsyncRespository<Category> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<CreateCategorycommandRespons> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCategoryCommandRespons = new CreateCategorycommandRespons();

            var validator = new CreateCategoryCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
            {
                createCategoryCommandRespons.Success = false;
                createCategoryCommandRespons.ValidationErrors = new List<string>();
                foreach (var error in validatorResult.Errors)
                {
                    createCategoryCommandRespons.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createCategoryCommandRespons.Success)
            {
                var category = new Category() { Name = request.Name };
                category = await _categoryRepository.AddAsync(category);
                createCategoryCommandRespons.Category = _mapper.Map<CreateCategoryDto>(category);
            }

            return createCategoryCommandRespons;
        }
    }
}
