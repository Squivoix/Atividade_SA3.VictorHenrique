using System;

namespace Atividade_SA3
{
	static class Menu
	{
		public static Agencia a1 = new ();

		#region AdicionarConta
		public static void AdicionarConta(string nome, string cpf, TipoDeContas tipoConta)
		{
			switch(tipoConta)
			{
				case TipoDeContas.Corrente :
				{
					a1.AdicionarContaCorrente(nome, cpf);
					break;
				}

				case TipoDeContas.CorrenteEspecial :
				{
					a1.AdicionarContaCorrenteEspecial(nome, cpf, 200f);
					break;
				}

				case TipoDeContas.Poupança :
				{
					a1.AdicionarContaPoupanca(nome, cpf);
					break;
				}
			}

		}
		
		public static void AdicionarConta(string nome, string cpf, decimal valor, TipoDeContas tipoConta)
		{
			switch(tipoConta)
			{
				case TipoDeContas.Corrente:
				{
					a1.AdicionarContaCorrente(nome, cpf, valor);
					break;
				}

				case TipoDeContas.CorrenteEspecial:
				{
					a1.AdicionarContaCorrenteEspecial(nome, cpf, valor, 200f);
					break;
				}

				case TipoDeContas.Poupança:
				{
					a1.AdicionarContaPoupanca(nome, cpf, valor);
					break;
				}
			}
		}
		#endregion

		#region FecharConta
		public static bool FecharConta(string cpf)
		{
			return a1.FecharConta(cpf);
		}
		#endregion

		#region Sacar Dinheiro
		public static bool SacarDinheiro(string cpf, decimal valor)
		{
			return EncontrarConta(cpf).Sacar(valor);
		}
		#endregion

		#region Depositar Dinheiro
		public static bool DepositarDinheiro(string cpf, decimal valor)
		{
			return EncontrarConta(cpf).Depositar(valor);
		} 
		
		public static bool DepositarDinheiro(string cpf1, string cpf2, decimal valor)
		{
			if(EncontrarConta(cpf1) is ContaCorrenteEspecial)
			{
				return EncontrarConta(cpf1).Depositar(valor, EncontrarConta(cpf2));
			}

			return EncontrarConta(cpf2).Depositar(valor, EncontrarConta(cpf1));
		}
		#endregion

		#region Visualizar Conta
		public static void VisualizarConta(string cpf)
		{
			Conta c = EncontrarConta(cpf);

			Console.WriteLine($"\n" +
			$"Agencia: {c.Agencia}\n" +
			$"Id: {c.IdConta}\n" +
			$"Tipo da conta: {c.Tipo}\n" +
			$"Nome: {c.Nome}\n" +
			$"CPF: {c.CPF}\n" +
			$"Valor: R${c.Valor}");
		}
		#endregion

		private static Conta EncontrarConta(string cpf)
		{
			return a1.Contas.Find(x => x.CPF == cpf);
		}
	}
}
