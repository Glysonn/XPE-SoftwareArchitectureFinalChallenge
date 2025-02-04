namespace ProdManager.Application.Interfaces;

public interface IUnitOfWork
{
    int Commit();
}