using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MarioLikeGame.Model;
namespace Mariolikegame.DAL
{
    public class GamerDAL
    {
        //Declarar o objeto de conexao com o BD
        private SqlConnection conexao;

        //Exibir as Mensagens de Erro
        public string MensagemErro { get; set; }

        public GamerDAL()
        {
            //Criar Objeto para ler a configuraçao
            LeitorConfiguracao leitor = new LeitorConfiguracao();

            //Instanciar a conexao
            conexao = new SqlConnection();
            conexao.ConnectionString = leitor.LerConexao();
        
        }

        public bool Inserir(Placar placar)
        {
            bool resultado = false;
            //Limpa mensagem de erro
            MensagemErro = "";

            //Declarar Comando SQL
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "INSERT INTO Jogador (Nome_Jogador, Score_Jogador, Date_Score_Jogador,Tempo_Jogador)" +
                " VALUES (@Nome,@Score,@Date,@Tempo)";

            //Criar os parametros
            comando.Parameters.AddWithValue("@Nome",placar.NomeJogador);
            comando.Parameters.AddWithValue("@Score", placar.ScoreJogador);
            comando.Parameters.AddWithValue("@Date", placar.DateScoreJogador);
            comando.Parameters.AddWithValue("@Tempo", placar.TempoJogador);

            //Executar o Comando
            try
            {
                //Abrir a conexao
                conexao.Open();
                //Executar o comando
                comando.ExecuteNonQuery();
                //Se chegou até aqui, entao fununciou! :)
                resultado = true;
            }
            catch (Exception ex)
            {

                //Se entrou aqui, entao deu pau
                MensagemErro = ex.Message;
            }
            finally
            {
                //Finalizar fechando a conexao
                conexao.Close();
            }
            return resultado;
        }

        public List<Placar> Listar()
        {
            //Instanciar a lista
            List<Placar> resultado = new List<Placar>();

            //Declarar o comando
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT TOP 10 Id_Jogador, Nome_Jogador, Score_Jogador, Date_Score_Jogador , Tempo_Jogador " +
                "FROM Jogador ORDER BY Score_Jogador DESC, Tempo_Jogador, Date_Score_Jogador";

            //Executar o comando
            try
            {
                //Abrir a conexao
                conexao.Open();

                //Executar o comando e receber o resultado
                SqlDataReader leitor = comando.ExecuteReader();

                //Verificarse encontrou algo
                while (leitor.Read() == true)
                {
                    //instancio o objeto
                    Placar placar = new Placar();
                    placar.IdJogador = Convert.ToInt32(leitor["Id_Jogador"]);
                    placar.NomeJogador = leitor["Nome_Jogador"].ToString();
                    placar.ScoreJogador = Convert.ToInt32(leitor["Score_Jogador"]);
                    placar.DateScoreJogador = Convert.ToDateTime(leitor["Date_Score_Jogador"]);
                    placar.TempoJogador = leitor["Tempo_Jogador"].ToString();

                    //Adicionar na lista
                    resultado.Add(placar);
                }

                //Fechar o leitor
                leitor.Close();
            }
            catch (Exception ex)
            {

                //Se entrou aqui entao deu pau :(
                string mensagem = ex.Message;
            }
            finally
            {
                conexao.Close();
            }
            return resultado;
        }
            

    }
}
