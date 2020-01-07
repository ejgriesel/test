using fundstrading.domain.Context;

namespace fundstrading.repositories
{
    public class BaseRepository
    {
        protected readonly FundstradingContext _context;

        public BaseRepository(FundstradingContext context)
        {
            _context = context;
        }
    }
}
