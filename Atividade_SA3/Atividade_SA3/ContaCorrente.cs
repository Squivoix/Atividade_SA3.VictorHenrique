
namespace Atividade_SA3
{
	class ContaCorrente : Conta
	{
		public ContaCorrente(int agencia, string nome, string cpf, TipoDeContas tipoConta) : base(agencia, nome, cpf, tipoConta) { }
		public ContaCorrente(int agencia, string nome, string cpf, decimal valor, TipoDeContas tipoConta) : base (agencia, nome, cpf, valor, tipoConta) { }
	}
}
