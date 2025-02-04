using ProdManager.Application.Interfaces;

namespace ProdManager.Infrastructure;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public int Commit()
    {
        return context.SaveChanges();
    }
}