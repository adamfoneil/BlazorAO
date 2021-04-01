using BlazorAO.Models;
using System.Threading.Tasks;

namespace BlazorAO.App.Data.Repositories
{
    public abstract class Repository<TModel> where TModel : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task<TModel> GetAsync(int id) => await _context.FindAsync<TModel>(id);       
        public abstract Task<TModel> GetAsync(int id);
    }


    public class ApprovedExpenseRepository : Repository<ApprovedExpense>
    {
        public ApprovedExpenseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<ApprovedExpense> GetAsync(int id) => await _context.FindAsync<ApprovedExpense>(id);
    }

    public class ApprovedWorkHoursRepository : Repository<ApprovedWorkHours>
    {
        public ApprovedWorkHoursRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<ApprovedWorkHours> GetAsync(int id) => await _context.FindAsync<ApprovedWorkHours>(id);
    }

    public class BudgetRepository : Repository<Budget>
    {
        public BudgetRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Budget> GetAsync(int id) => await _context.FindAsync<Budget>(id);
    }

    public class ClientRepository : Repository<Client>
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Client> GetAsync(int id) => await _context.FindAsync<Client>(id);
    }

    public class ExpenseRepository : Repository<Expense>
    {
        public ExpenseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Expense> GetAsync(int id) => await _context.FindAsync<Expense>(id);
    }

    public class InvoiceRepository : Repository<Invoice>
    {
        public InvoiceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Invoice> GetAsync(int id) => await _context.FindAsync<Invoice>(id);
    }

    public class InvoicedWorkRecordRepository : Repository<InvoicedWorkRecord>
    {
        public InvoicedWorkRecordRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<InvoicedWorkRecord> GetAsync(int id) => await _context.FindAsync<InvoicedWorkRecord>(id);
    }

    public class InvoiceRateRepository : Repository<InvoiceRate>
    {
        public InvoiceRateRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<InvoiceRate> GetAsync(int id) => await _context.FindAsync<InvoiceRate>(id);
    }

    public class JobRepository : Repository<Job>
    {
        public JobRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Job> GetAsync(int id) => await _context.FindAsync<Job>(id);
    }

    public class PermissionRepository : Repository<Permission>
    {
        public PermissionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Permission> GetAsync(int id) => await _context.FindAsync<Permission>(id);
    }

    public class RecurringTaskRepository : Repository<RecurringTask>
    {
        public RecurringTaskRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<RecurringTask> GetAsync(int id) => await _context.FindAsync<RecurringTask>(id);
    }

    public class RecurringTaskTypeRepository : Repository<RecurringTaskType>
    {
        public RecurringTaskTypeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<RecurringTaskType> GetAsync(int id) => await _context.FindAsync<RecurringTaskType>(id);
    }

    public class RoleRepository : Repository<Role>
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Role> GetAsync(int id) => await _context.FindAsync<Role>(id);
    }

    public class UserProfileRepository : Repository<UserProfile>
    {
        public UserProfileRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<UserProfile> GetAsync(int id) => await _context.FindAsync<UserProfile>(id);
    }

    public class WorkHoursRepository : Repository<WorkHours>
    {
        public WorkHoursRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<WorkHours> GetAsync(int id) => await _context.FindAsync<WorkHours>(id);
    }

    public class WorkspaceRepository : Repository<Workspace>
    {
        public WorkspaceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Workspace> GetAsync(int id) => await _context.FindAsync<Workspace>(id);
    }

    public class WorkspaceUserRepository : Repository<WorkspaceUser>
    {
        public WorkspaceUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<WorkspaceUser> GetAsync(int id) => await _context.FindAsync<WorkspaceUser>(id);
    }

    public class WorkspaceUserPermissionRepository : Repository<WorkspaceUserPermission>
    {
        public WorkspaceUserPermissionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<WorkspaceUserPermission> GetAsync(int id) => await _context.FindAsync<WorkspaceUserPermission>(id);
    }

    public class WorkTypeRepository : Repository<WorkType>
    {
        public WorkTypeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<WorkType> GetAsync(int id) => await _context.FindAsync<WorkType>(id);
    }


}
