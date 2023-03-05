using base_api_aspNet.Models;
using base_api_aspNet.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace base_api_aspNet.Repository.Interfaces
{
    public interface IBaseRepository
    {
        Task<List<BaseDto>> BuscarTodos();
        Task<BaseDto> Adicionar(Base nbase);
        Task<BaseDto> Atualizar(Guid id, Base ubase);
        Task<Boolean> Deletar(Guid id);
        Task<BaseDto> BuscarPorID(Guid id);
    }
}
