
namespace WolfUniversity.Domain
{
    public class GradeService : BaseService, IGradeServiceInterface
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<Grade> AddGradeAsync(Grade model)
        {
            var grade = await _gradeRepository.AddAsync(model);
            await UnitOfWork.CommitAsync();
            return grade;
        }

        public async Task<Grade> UpdateGradeAsync(Grade model)
        {
            var grade = await _gradeRepository.UpdateAsync(model);
            await UnitOfWork.CommitAsync();
            return grade;
        }

        public async Task<string> GetGradeDescription(int GradeId)
        {
            var gradeDescription = await _gradeRepository.GetAsync(g=>g.GradeId==GradeId);

            return gradeDescription.GradeDescription;
        }

    }
}
