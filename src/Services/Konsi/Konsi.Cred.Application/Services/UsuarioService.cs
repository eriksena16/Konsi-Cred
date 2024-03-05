//using AssetTrack.Core;
//using AssetTrack.Patrimony.Domain;
//using AssetTrack.Patrimony.Domain.Interfaces.Repositories;

//namespace AssetTrack.Patrimony.Application.Services
//{
//    public class UsuarioService : ServiceBase/*, IUsuarioService*/
//    {
//        private readonly IUsuarioRepository _usuarioRepository;
//        public UsuarioService(IUsuarioRepository usuarioRepository, INotifier notifier) : base(notifier)
//        {
//            _usuarioRepository = usuarioRepository;
//        }

        //public async Task<bool> Inserir(UsuarioDTQ usuarioDTQ)
        //{
        //    var usuario = AutoMapperUsuario.ParaUsuario(usuarioDTQ);

        //    if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return false;

        //    if (_usuarioRepository.Buscar(p => p.Nome == usuario.Nome && p.ContaId == usuario.ContaId).Result.Any())
        //    {
        //        Notificar(SgiErrorMessages.ERROR_CATEGORY_EXISTS);
        //        return false;
        //    }

        //    var resultado = await _usuarioRepository.Adicionar(usuario);

        //    if(resultado) usuarioDTQ.Id = usuario.Id;
            
        //    return resultado;

        //}
        //public async Task<bool> Atualizar(Usuario category)
        //{
        //    if (!ExecutarValidacao(new UsuarioValidation(), category)) return false;

        //    if (_usuarioRepository.Buscar(p => p.Nome == category.Nome && p.Id != category.Id && p.ContaId == category.ContaId).Result.Any())
        //    {
        //        Notificar(SgiErrorMessages.ERROR_CATEGORY_EXISTS);
        //        return false;
        //    }

        //    await _usuarioRepository.Atualizar(category);
        //    return true;
        //}

        //public async Task Excluir(long id)
        //{
        //    await _usuarioRepository.Excluir(id);
        //}

//        public void Dispose()
//        {
//            _usuarioRepository?.Dispose();
//        }
//    }
//}
