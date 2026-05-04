using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValeAtivos324123036.Data;
using ValeAtivos324123036.Models;

namespace ValeAtivos324123036.Controllers
{
    public class EquipamentoInput
    {
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Localizacao { get; set; } = string.Empty;
        public double CapacidadeProcessamento { get; set; }
        public DateTime DataUltimaManutencao { get; set; }
        public bool EmOperacao { get; set; }
    }

    [ApiController]
    [Route("api/equipamentos")]
    public class EquipamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EquipamentosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/equipamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipamento>>> GetEquipamentos()
        {
            return await _context.Equipamentos.ToListAsync();
        }

        // GET: api/equipamentos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipamento>> GetEquipamento(int id)
        {
            var equipamento = await _context.Equipamentos.FindAsync(id);

            if (equipamento == null)
                return NotFound($"Equipamento com Id {id} não encontrado.");

            return equipamento;
        }

        // POST: api/equipamentos
        [HttpPost]
        public async Task<ActionResult<Equipamento>> PostEquipamento(EquipamentoInput input)
        {
            var equipamento = new Equipamento
            {
                Nome = input.Nome,
                Tipo = input.Tipo,
                Localizacao = input.Localizacao,
                CapacidadeProcessamento = input.CapacidadeProcessamento,
                DataUltimaManutencao = input.DataUltimaManutencao,
                EmOperacao = input.EmOperacao
            };

            _context.Equipamentos.Add(equipamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEquipamento), new { id = equipamento.Id }, equipamento);
        }
    }
}
