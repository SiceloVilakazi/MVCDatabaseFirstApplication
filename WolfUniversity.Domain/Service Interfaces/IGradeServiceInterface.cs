
namespace WolfUniversity.Domain
{
    public interface IGradeServiceInterface
    {
        Task<Grade> AddGradeAsync(Grade grade);
        Task<Grade> UpdateGradeAsync(Grade newGrade);

        Task<string> GetGradeDescription(int GradeId);
    }
}
