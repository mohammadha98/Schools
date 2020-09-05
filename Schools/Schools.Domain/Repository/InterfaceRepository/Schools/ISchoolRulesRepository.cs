using Schools.Domain.Models.Schools;

namespace Schools.Domain.Repository.InterfaceRepository.Schools
{
    public interface ISchoolRulesRepository
    {
        SchoolRules GetRule();
        void AddRule(SchoolRules rule);
        void EditRule(SchoolRules rule);
    }
}