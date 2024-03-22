﻿using System.Net;

namespace Konsi.Core
{
    public class MenssagemHttp
    {
        private string _menssagem;
        public string Menssagem
        {
            get { return _menssagem; }
            set { _menssagem = value; }
        }
        public HttpStatusCode StatusCode { get; set; }
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
