using System;

namespace Atividade_SA3
{
	class ContaCorrenteEspecial : ContaCorrente
	{
		public readonly float LimiteChequeEspecial;

		public ContaCorrenteEspecial(int agencia, string nome, string cpf, float limite, TipoDeContas tipoConta) : base(agencia, nome, cpf, tipoConta)
		{
			LimiteChequeEspecial = limite;
		}

		public ContaCorrenteEspecial(int agencia, string nome, string cpf, decimal valor, float limite, TipoDeContas tipoConta) : base(agencia, nome, cpf, valor, tipoConta)
		{
			LimiteChequeEspecial = limite;
		}

		public override bool Sacar(decimal valor)
		{
			if((Valor - valor) >= ((decimal)-LimiteChequeEspecial)) // Se o valor do saque ainda for maior que o Limite.
			{
				Valor -= valor;
				return true;
			}

			return false;
		}

		public override bool Depositar(decimal valor, Conta c)
		{
			if((Valor - valor) >= (-(decimal)LimiteChequeEspecial))
			{
				c.Valor += valor;
				Valor -= valor;
				return true;
			}

			return false;
		}
	}
}
