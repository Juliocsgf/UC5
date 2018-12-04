using System;
using System.Collections.Generic;
using System.Text;

namespace MarioLikeGame.Model
{
    public class Placar
    {
        //Selecionar/Botao Direito/Quick Actions/Penultimo ou ultimo
        //Modo Camel Case
        private int idJogador;
        public string nomeJogador;
        public int scoreJogador;
        public DateTime dateScoreJogador;
        private string tempoJogador;

        public Placar()
        {        

        }

        public Placar(int idJogador, string nomeJogador, int scoreJogador, DateTime dateScoreJogador, string tempoJogador)
        {
            IdJogador = idJogador;
            NomeJogador = nomeJogador;
            ScoreJogador = scoreJogador;
            DateScoreJogador = dateScoreJogador;
            TempoJogador = tempoJogador;
        }

        

        //Getters and Setters
        public int IdJogador { get => idJogador; set => idJogador = value; }
        public string NomeJogador { get => nomeJogador; set => nomeJogador = value; }
        public int ScoreJogador { get => scoreJogador; set => scoreJogador = value; }
        public DateTime DateScoreJogador { get => dateScoreJogador; set => dateScoreJogador = value; }
        public string TempoJogador { get => tempoJogador; set => tempoJogador = value; }



        //Apenas para treinar
        //public Placar(int id_Jogador2, char nome_Jogador2)
        //{
        //    this.IdJogador2 = id_Jogador2;
        //    this.NomeJogador2 = nome_Jogador2;
        //}

        //public int IdJogador2 { get => IdJogador2; set => IdJogador2 = value; }
        //public char NomeJogador2 { get => NomeJogador2; set => NomeJogador2 = value; }

    }
}
