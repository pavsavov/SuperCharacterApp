﻿namespace SuperCharactersApp.Services.CRUD.Services
{
    using AutoMapper;
    using SuperCharacters.Models;
    using SuperCharacters.Services.Mapping;
    using SuperCharactersApp.Repository.Contracts;
    using SuperCharactersApp.Services.CRUD.Services.Contracts;
    using SuperCharactersApp.ViewModels.DTO.TeamViewModels;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This class is responsible for all CRUD operations on Teams Entity.
    /// It receives input from respective controller and forwards parameters to the GenericRepository class with registered type
    /// in the UnitOfWork class. Also when needed, here happens the actual mapping from ViewModel to real Db model using Automapper.
    /// </summary>
    public class TeamServices : IService<TeamViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Create(TeamViewModel model)
        {
            var team = Mapper.Map<Team>(model);
            var success = _unitOfWork.TeamRepository.Create(team);

            if (success)
            {
                _unitOfWork.Save();
                return true;
            }

            return false;
        }

        public bool DeleteById(string id)
        {
            if (id != null)
            {
                _unitOfWork.TeamRepository.DeleteById(id);
                _unitOfWork.Save();

                return true;
            }

            return false;
        }

        public IEnumerable<TeamViewModel> GetAll()
        {
            var teams = _unitOfWork.TeamRepository.GetAll();

            var mappedTeams = teams.AsQueryable()
               .To<TeamViewModel>()
               .ToList();

            return mappedTeams;
        }

        public TeamViewModel GetById(string id)
        {
            var team = _unitOfWork.TeamRepository
                .GetById(id);

            var mappedTeam = Mapper.Map<TeamViewModel>(team);

            return mappedTeam;
        }

        public void Edit(TeamViewModel editModel)
        {
            var teamMapped = Mapper.Map<Team>(editModel);

            ManuallyPassValueToEachProperty(teamMapped);

            _unitOfWork.Save();
        }

        #region SupportiveMethodsForCRUDoperations

        public void ManuallyPassValueToEachProperty(Team teamMapped)
        {
            var team = _unitOfWork.TeamRepository.GetById(teamMapped.Id);

            team.Id = teamMapped.Id;
            team.TeamName = teamMapped.TeamName;

        }
        #endregion
    }
}
