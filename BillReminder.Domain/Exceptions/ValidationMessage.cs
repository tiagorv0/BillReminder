
namespace BillReminder.Domain.Exceptions;

public static class ValidationMessage
{
    public static string SenhaInvalida => "A senha deve conter caracteres especiais, ao menos uma letra maiuscula e ao menos um número";
    public static string UsuarioNaoEncontrado => "Usuário não encontrado";
}
