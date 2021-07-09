
namespace Atividade_SA3
{
	interface IConta
	{
		int Agencia { get; set; }
		int IdConta { get; set; }
		string Nome { get; set; }
		string CPF { get; set; }
		decimal Valor { get; set; }
		TipoDeContas Tipo { get; set; }

		public bool Sacar(decimal valor);
		public bool Depositar(decimal valor);
		public bool Depositar(decimal valor, Conta c);

	}
}
