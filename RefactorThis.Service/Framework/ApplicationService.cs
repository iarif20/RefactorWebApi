using AutoMapper;
using RefactorThis.Data;
using RefactorThis.Data.Repositories;

namespace RefactorThis.Service.Framework
{
    public abstract class ApplicationService : IApplicationService 
    {
        protected ApplicationService()
        {
            
        }

        // Todo: Remove it
        private IUnitOfWork _unitOfWork;
        // Todo: Remove it
        private IUnitOfWork UnitOfWork
        {
            get
            {
                if (_unitOfWork == null)
                {
                    _unitOfWork = new UnitOfWork(new ProductContext());
                }

                return _unitOfWork;
            }
        }

        private IMapper _mapper;
        public IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    _mapper = new Mapper(new MapperConfiguration(
                        configure=> configure.AddMaps(typeof(ApplicationService).Assembly)));
                }
                return _mapper;
            }
        }



    }
}