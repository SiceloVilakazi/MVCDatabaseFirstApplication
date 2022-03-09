

namespace WolfUniversity.Domain
{
    public class BaseService
    {
        IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected internal IUnitOfWork UnitOfWork { get; set; }
    }
}
