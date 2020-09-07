using Schools.Domain.Models;

namespace Schools.Domain.Repository.InterfaceRepository.Schools
{
    public interface ISchoolRulesRepository
    {
        Rules GetRule();
        void AddRule(Rules rule);
        void EditRule(Rules rule);
    }
}