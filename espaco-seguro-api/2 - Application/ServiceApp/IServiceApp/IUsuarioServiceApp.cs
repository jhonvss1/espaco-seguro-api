using espaco_seguro_api._2___Application.Request;
using espaco_seguro_api._2___Application.ViewModels;
using espaco_seguro_api._3___Domain.Entities;

namespace espaco_seguro_api._2___Application.ServiceApp.IServiceApp;

public interface IUsuarioServiceApp
{
    Task<UsuarioResponse> Criar(UsuarioRequestVm usuarioVm);
    Task<UsuarioResponse> ObterPorId(Guid id);
    Task<UsuarioResponse> Atualizar(UsuarioRequestVm usuarioVm, Guid id);
    Task <List<UsuarioResponse>> ObterTodos();
    Task<UsuarioResponse> Remover(Guid id);
    
}