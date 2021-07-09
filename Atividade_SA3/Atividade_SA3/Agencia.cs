using System;
using System.Collections.Generic;

namespace Atividade_SA3
{
	class Agencia
	{
		public List<Conta> Contas;
		public readonly int NumeroAgencia;
		private static int TotalAgencia = 1;

		public Agencia()
		{
			Contas = new();
			NumeroAgencia = TotalAgencia++;
		}

		#region Conta Corrente
		public void AdicionarContaCorrente(string nome, string cpf)
		{
			//Adicionar se não houver outra conta já criada, sem dinheiro de entrada.
			if(!ExisteConta(cpf)) 
			{
				Contas.Add(new ContaCorrente(NumeroAgencia, nome, cpf, TipoDeContas.Corrente));
				Console.WriteLine($"Conta Corrente {nome} criada com sucesso!");
			} else
			{
				Console.WriteLine($"Conta com o CPF {cpf} já existe!");
			}
		}
		
		public void AdicionarContaCorrente(string nome, string cpf, decimal valor)
		{
			//Adicionar se não houver outra conta já criada, com dinheiro de entrada.
			if(!ExisteConta(cpf))
			{
				Contas.Add(new ContaCorrente(NumeroAgencia, nome, cpf, valor, TipoDeContas.Corrente));
				Console.WriteLine($"Conta Corrente '{nome}' adicionada com valor de 'R${valor}' com sucesso!");
			} else
			{
				Console.WriteLine($"Conta com o CPF {cpf} já existe!");
			}
		}
		#endregion

		#region Conta Corrente Especial
		public void AdicionarContaCorrenteEspecial(string nome, string cpf, float limite)
		{
			//Adicionar se não houver outra conta já criada, sem dinheiro de entrada.
			if(!ExisteConta(cpf))
			{
				Contas.Add(new ContaCorrenteEspecial(NumeroAgencia, nome, cpf, limite, TipoDeContas.CorrenteEspecial));
				Console.WriteLine($"Conta Corrente Especial {nome} adicionada com limite de {200f} com sucesso!");
			} else
			{
				Console.WriteLine($"Conta com o CPF {cpf} já existe!");
			}
		}
		
		public void AdicionarContaCorrenteEspecial(string nome, string cpf, decimal valor, float limite)
		{
			//Adicionar se não houver outra conta já criada, com dinheiro de entrada.
			if(!ExisteConta(cpf))
			{
				Contas.Add(new ContaCorrenteEspecial(NumeroAgencia, nome, cpf, valor, limite, TipoDeContas.CorrenteEspecial));
				Console.WriteLine($"Conta Corrente Especial '{nome}' adicionada com valor de 'R${valor}' e limite de 'R${200f}' com sucesso!");
			} else
			{
				Console.WriteLine($"Conta com o CPF {cpf} já existe!");
			}
		}
		#endregion

		#region Conta Poupança
		public void AdicionarContaPoupanca(string nome, string cpf)
		{
			//Adicionar se não houver outra conta já criada, sem dinheiro de entrada.
			if(!ExisteConta(cpf))
			{
				Contas.Add(new ContaPoupanca(NumeroAgencia, nome, cpf, TipoDeContas.Poupança));
				Console.WriteLine($"Conta Poupança {nome} adicionada com sucesso!");
			} else
			{
				Console.WriteLine($"Conta com o CPF {cpf} já existe!");
			}
		}
		
		public void AdicionarContaPoupanca(string nome, string cpf, decimal valor)
		{
			//Adicionar se não houver outra conta já criada, com dinheiro de entrada.
			if(!ExisteConta(cpf))
			{
				Contas.Add(new ContaPoupanca(NumeroAgencia, nome, cpf, valor, TipoDeContas.Poupança));
				Console.WriteLine($"Conta Poupança '{nome}' adicionada com valor de 'R${valor}' com sucesso!");
			} else
			{
				Console.WriteLine($"Conta com o CPF {cpf} já existe!");
			}
		}
		#endregion

		public bool FecharConta(string cpf)
		{
			//Fecha uma conta com um certo CPF se existe.
			Conta c = Contas.Find(x => x.CPF == cpf);

			if(Contas.Contains(c))
			{
				Contas.Remove(c);
				return true;
			}

			return false;
		}

		private bool ExisteConta(string cpf)
		{
			// Checa se existe uma conta criada com um certo CPF.
			return Contas.Contains(Contas.Find(x => x.CPF == cpf));
		}
		
	}
}
