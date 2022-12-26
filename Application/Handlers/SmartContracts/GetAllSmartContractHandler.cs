﻿using Application.CQRS.Queries;
using Domain.Models;
using Infrastructure.Persistence.Interfaces;
using MediatR;

namespace Application.Handlers.SmartContracts
{
    public class GetAllSmartContractHandler : IRequestHandler<GetSmartContractsListQuery, IEnumerable<SmartContract>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSmartContractHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SmartContract>> Handle(GetSmartContractsListQuery request, CancellationToken cancellationToken)
        {
            var allSmartContracts = await _unitOfWork.SmartContractRepository.GetSmartContracts();
            return allSmartContracts;
        }
    }
}