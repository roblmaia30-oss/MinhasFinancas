using MinhasFinancas.Aplicacao.Interfaces;
using MinhasFinancas.Dominio.Entidades;

namespace MinhasFinancas.Aplicacao.CasosDeUso.RealizarTransferencia;

public class RealizarTransferencia(
    IContaRepositorio contaRepositorio, 
    ITransferenciaRepositorio transferenciaRepositorio)
{
    private readonly IContaRepositorio _contaRepositorio = contaRepositorio;
    private readonly ITransferenciaRepositorio _transferenciaRepositorio = transferenciaRepositorio;

    public async Task Executar(RealizarTransferenciaRequest request)
    {
        var origem = await _contaRepositorio.ObterPorId(request.ContaOrigemId) 
                     ?? throw new Exception("Conta de origem não encontrada!");
        
        var destino = await _contaRepositorio.ObterPorId(request.ContaDestinoId) 
                      ?? throw new Exception("Conta de destino não encontrada!");

        origem.Debitar(request.Valor);
        destino.Creditar(request.Valor);

        var transferencia = new Transferencia(
            descricao: request.Descricao,
            valor: request.Valor,
            data: request.Data,
            origemId: origem.Id,
            destinoId: destino.Id
        );

        await _contaRepositorio.Atualizar(origem);
        await _contaRepositorio.Atualizar(destino);
        await _transferenciaRepositorio.Salvar(transferencia);
    }
}