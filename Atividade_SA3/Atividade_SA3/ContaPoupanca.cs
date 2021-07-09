
namespace Atividade_SA3
{
	class ContaPoupanca : Conta
	{
		readonly float Juros = 2.5f;

		public ContaPoupanca(int agencia, string nome, string cpf, TipoDeContas tipoConta) : base(agencia, nome, cpf, tipoConta) { }

		public ContaPoupanca(int agencia, string nome, string cpf, decimal valor, TipoDeContas tipoConta) : base(agencia, nome, cpf, valor, tipoConta) { }

		public void Render(int meses)
		{
			Valor += Valor * ((1 + (decimal)Juros) * meses);
		}
	}
}
