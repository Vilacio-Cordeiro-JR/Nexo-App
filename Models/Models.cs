using System;
namespace Nexo_App.Models
{
    public class Usuario
    {
        public int    CdUsuario   { get; set; }
        public string NmUsuario   { get; set; }
        public string NmEmail     { get; set; }
        public string DsSenhaHash { get; set; }
        public string NmTelefone  { get; set; }
        public string CdCep       { get; set; }
        public string NmRua       { get; set; }
        public string NmBairro    { get; set; }
        public string NmCidade    { get; set; }
        public string SgEstado    { get; set; }
        public string IcTipo      { get; set; } // "USER" ou "ADMIN"
    }

    public class Viagem
    {
        public int      CdViagem   { get; set; }
        public string   NmOrigem   { get; set; }
        public string   NmDestino  { get; set; }
        public DateTime DtViagem   { get; set; }
        public decimal  VlPreco    { get; set; }
        public int      QtLivres   { get; set; } // usado só na listagem
    }

    public class Assento
    {
        public int    CdAssento  { get; set; }
        public int    QtNumero   { get; set; }
        public int    CdViagem   { get; set; }
        public string IcStatus   { get; set; } // "LIVRE" ou "OCUPADO"
    }

    public class Reserva
    {
        public int      CdReserva   { get; set; }
        public int      CdUsuario   { get; set; }
        public int      CdViagem    { get; set; }
        public DateTime DtReserva   { get; set; }
        public string   IcStatus    { get; set; }
        // para exibição no grid
        public string   NmUsuario   { get; set; }
        public string   NmOrigem    { get; set; }
        public string   NmDestino   { get; set; }
        public string   Assentos    { get; set; }
    }
}
