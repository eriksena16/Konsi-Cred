using Microsoft.FluentUI.AspNetCore.Components;

namespace KonsiCred.Web
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }

        private string _menssagem;
        public string Menssagem
        {
            get { return _menssagem; }
            set { _menssagem = value; }
        }

        private string[] _errors;
        public string[] errors
        {
            get { return _errors; }
            set
            {
                _errors = value;
                AdicionarErrosAMenssagem();
            }
        }
        private void AdicionarErrosAMenssagem()
        {
            if (_errors != null && _errors.Length > 0)
            {
                Menssagem += string.Join("\n", _errors);
            }
        }
    }
}
