﻿using GymHub.DataAccess;

namespace GymHub.Services
{
    public class DietService : IDietService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DietService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void GetTraineeDiets(int traineeId)
        {

        }
    }
}