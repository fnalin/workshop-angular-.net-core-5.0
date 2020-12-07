using System.Threading.Tasks;
using FN.WorkShopNetCoreAngular.Domain.Contracts.Repositories;
using FN.WorkShopNetCoreAngular.API.Models.Clientes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FN.WorkShopNetCoreAngular.Domain.Contracts.Infra;

namespace FN.WorkShopNetCoreAngular.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _uow;

        public ClientesController(IClienteRepository cliRepo, IUnitOfWork uow)
        {
            _clienteRepository = cliRepo;
            _uow = uow;
        }

        /// <summary>
        /// Lista todos os Clientes.
        /// </summary>
        /// <returns>Uma lista de Clientes</returns>
        /// <response code="200">Clientes retornardos com sucesso</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _clienteRepository.GetAsync();
            var model = data.Select(m => m.ToGetAllModel());
            return Ok(model);
        }

        /// <summary>
        /// Lista um cliente.
        /// </summary>
        /// <returns>Cliente</returns>
        /// <response code="200">Cliente retornardo com sucesso</response>
        /// <response code="404">Cliente não encontrado</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}", Name = "GetClienteById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _clienteRepository.GetAsync(id);

            if (data == null)
                return NotFound();

            return Ok(data.ToGetByIdModel());
        }

        /// <summary>
        /// Adiciona um novo cliente.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///     POST /Clientes
        ///     {
        ///         "nome": "Mais um",
        ///         "sobrenome": "Silva",
        ///         "idade": 50,
        ///         "sexo": 1
        ///     }
        /// </remarks>
        /// <param name="command">Dados do cliente</param>
        /// <returns>Novo cliente</returns>
        /// <response code="201">Retorna o novo cliente cadastrado</response>
        /// <response code="400">Caso o request seja inválido ou seja nulo</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Add(
                        [FromBody] Add command
            )
        {
            if (ModelState.IsValid)
            {

                var cliente = command.ToEntity();
                _clienteRepository.Add(cliente);

                await _uow.CommitAsync();

                var model = cliente.ToGetByIdModel();

                return CreatedAtRoute("GetClienteById", new { cliente.Id }, model);
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Edita um usuário existente.
        /// </summary>
        /// <remarks>
       ///     Put /Clientes/1
        ///     {
        ///         "nome": "Mais um alterado",
        ///         "sobrenome": "Silva",
        ///         "idade": 51,
        ///         "sexo": 1
        ///     }
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns>Usuário editado</returns>
        /// <response code="204">Retorna ok</response>
        /// <response code="400">Caso o request seja nulo</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] Update command)
        {
            if (id != command.Id) ModelState.AddModelError("id","os ids não conferem");


            if (ModelState.IsValid)
            {

                var cliente = await _clienteRepository.GetAsync(id);
                if (cliente == null){
                    ModelState.AddModelError("id","cliente não localizado");
                    return BadRequest(ModelState);
                }

                cliente.Alterar(command.Nome, command.Sobrenome, command.Idade, command.Sexo);
                _clienteRepository.Edit(cliente);

                await _uow.CommitAsync();

                return NoContent();
            }

            return BadRequest(ModelState);
        }


        /// <summary>
        /// Exclui um cliente.
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <response code="204">Confirmação</response>
        /// <response code="400">Caso o id seja nulo ou não inexistente</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _clienteRepository.GetAsync(id);
            
            if (cliente == null) {
                ModelState.AddModelError("id", "cliente não localizado");
                return BadRequest(ModelState);
            }

            _clienteRepository.Del(cliente);
            await _uow.CommitAsync();
            return NoContent();

        }
    }
}