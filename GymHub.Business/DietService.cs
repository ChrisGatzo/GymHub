﻿using GymHub.DataAccess.Infrastructure;

namespace GymHub.Service
{
    public class DietService : IDietService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DietService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void GetAthleteDiets(int athleteId)
        {

        }
    }
}