
using Microsoft.Win32;
using RiskBackend.Repository;
using RiskProject.Dtos;
using RiskProject.Repository;
using RiskProject.Services.Interfaces;
using System.Threading.Tasks;
using System;

namespace RiskProject.Services
{
    public class RegisterService : IRegisterService
    {
        IRegisterRepository _repo = new RegisterRepository();

        public TblRegister Create(RegisterDTO register)
        {
            TblRegister newRegister = new TblRegister
            {
                Id = Guid.NewGuid().ToString(),
                ProjectId = register.ProjectId.ToString(),
                TaskId = Guid.NewGuid().ToString(),
                TaskDescription = register.TaskDescription,
                UpdatedAt = null,
                Active = true,
                TblDetails = register.Details.Select(x => {
                            return new TblDetail
                            {
                                Id = Guid.NewGuid().ToString(),
                                RiskDescription = x.RiskDescription,
                                ImpactDescription = x.ImpactDescription,
                                ProbabilityId = x.ProbabilityId.ToString(),
                                ImpactId = x.ImpactId.ToString(),
                                Owner = x.Owner,
                                ResponsePlan = x.ResponsePlan,
                                PriorityId = x.PriorityId.ToString(),
                                Points = x.Points
                            };
                        }).ToList()
            };

            _repo.Insert(newRegister);
            return newRegister;
        }

        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<TblRegister> Get()
        {
            return _repo.GetAll();
        }

        public TblRegister GetById(Guid id)
        {
            return _repo.GetById(id);
        }

        public TblRegister Update(Guid id, RegisterDTO register)
        {
            _repo.RemoveRelated(register.Id);

            TblRegister updatedRegister = _repo.GetById(id);
            updatedRegister.Id = id.ToString();
            updatedRegister.ProjectId = register.ProjectId.ToString();
            updatedRegister.TaskId = register.TaskId.ToString();
            updatedRegister.TaskDescription = register.TaskDescription;
            updatedRegister.UpdatedAt = new DateTime();

            updatedRegister.TblDetails = register.Details.Select(x => {
                    return new TblDetail
                    {
                        Id = Guid.NewGuid().ToString(),
                        RiskDescription = x.RiskDescription,
                        ImpactDescription = x.ImpactDescription,
                        ProbabilityId = x.ProbabilityId.ToString(),
                        ImpactId = x.ImpactId.ToString(),
                        Owner = x.Owner,
                        ResponsePlan = x.ResponsePlan,
                        PriorityId = x.PriorityId.ToString(),
                        Points = x.Points
                    };
                }).ToList();

            _repo.Update(updatedRegister);

            

            return updatedRegister;
        }
    }
}
