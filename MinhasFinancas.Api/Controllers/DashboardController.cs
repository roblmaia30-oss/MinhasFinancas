using Microsoft.AspNetCore.Mvc;
using MinhasFinancas.Aplicacao.CasosDeUso.ObterResumoMensal;

namespace MinhasFinancas.Api.Controllers;

// Isso diz que essa classe responde a URLs da internet
[ApiController] 
[Route("api/[controller]")] // A URL será: http://localhost:porta/api/dashboard
public class DashboardController(ObterResumoMensal obterResumoMensal) : ControllerBase
{
    private readonly ObterResumoMensal _obterResumoMensal = obterResumoMensal;

    // Responde ao método GET (quando alguém acessa a URL pelo navegador)
    // Exemplo de URL: api/dashboard/2026/5
    [HttpGet("{ano}/{mes}")]
    public async Task<IActionResult> ObterResumo(int ano, int mes)
    {
        // 1. Monta o Request
        var request = new ObterResumoMensalRequest(mes, ano);

        // 2. Chama o Maestro (Caso de Uso)
        var response = await _obterResumoMensal.Executar(request);

        // 3. Devolve o Response com o status 200 (OK) em formato JSON
        return Ok(response);
    }
}