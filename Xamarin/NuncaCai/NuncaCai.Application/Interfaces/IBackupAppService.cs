using System.Threading.Tasks;

namespace NuncaCai.Application.Interfaces
{
    public interface IBackupAppService
    {
        Task<bool> ExecuteBackup();
        Task<bool> RestoreBackup();
    }
}
