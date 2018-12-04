using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Mariolikegame.DAL
{
    class LeitorConfiguracao
    {
        public string LerConexao()
        {
            string resultado = "";

            //Ler string de Configuraçao
            resultado = ConfigurationManager.ConnectionStrings
                ["MarioLikeGame.Properties.Settings.Conexao"].ConnectionString;
            return resultado;
        }
    }
}
