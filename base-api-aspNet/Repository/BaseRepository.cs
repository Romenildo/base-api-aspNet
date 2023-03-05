using AutoMapper;
using base_api_aspNet.Data;
using base_api_aspNet.Models;
using base_api_aspNet.Models.Dtos;
using base_api_aspNet.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace base_api_aspNet.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly DataContext _dbcontext;
        private readonly IMapper _mapper;

        public BaseRepository(DataContext dataContext, IMapper mapper)
        {
            _dbcontext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<BaseDto>> BuscarTodos()
        {
            return await _dbcontext.Bases
                   .Select(x => new BaseDto { Id = x.Id, Nome = x.Nome, Idade = x.Idade, Data = x.Data })
                   .ToListAsync();
        }
        public async Task<BaseDto> BuscarPorID(Guid id)
        {
            var resultado = await _dbcontext.Bases.FirstOrDefaultAsync(x => x.Id == id);
            var resultadoDto = _mapper.Map<BaseDto>(resultado);
            return resultadoDto;
        }

        public async Task<BaseDto> Adicionar(Base nbase)
        {
            Base BaseBd = await _dbcontext.Bases.FirstOrDefaultAsync(x => x.Nome == nbase.Nome);

            if (BaseBd != null)
            {
                throw new Exception("Base Já cadastrado!");
            }

            nbase.Id = new Guid();
            nbase.Criado_em = DateTime.Now;

            await _dbcontext.Bases.AddAsync(nbase);
            await _dbcontext.SaveChangesAsync();
            var resultadoDto = _mapper.Map<BaseDto>(nbase);

            return resultadoDto;
        }

        public async Task<BaseDto> Atualizar(Guid id, Base ubase)
        {
            Base baseBd = await _dbcontext.Bases.FirstOrDefaultAsync(x => x.Id == id);

            if (baseBd == null)
            {
                throw new Exception($"Base com Id: {id} não encontrado!");
            }
            _dbcontext.Bases.Remove(baseBd);
            await _dbcontext.SaveChangesAsync();

            baseBd.Nome = ubase.Nome;
            baseBd.Data = ubase.Data;
            baseBd.Idade = ubase.Idade;
            baseBd.Criado_em = DateTime.Now;



            await _dbcontext.Bases.AddAsync(baseBd);
            await _dbcontext.SaveChangesAsync();

            var resultadoDto = _mapper.Map<BaseDto>(baseBd);
            return resultadoDto;
        }

        public async Task<Boolean> Deletar(Guid id)
        {
            Base BaseBd = await _dbcontext.Bases.FirstOrDefaultAsync(x => x.Id == id);

            if (BaseBd == null)
            {
                throw new Exception($"Base com Id: {id} não encontrado!");
            }
            _dbcontext.Bases.Remove(BaseBd);
            await _dbcontext.SaveChangesAsync();

            return true;
        }

    }
}

