
namespace Atividade_SA3
{
	abstract class Conta : IConta
	{
		public int Agencia { get; set; }
		public int IdConta { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public decimal Valor { get; set; }
		public TipoDeContas Tipo { get; set; }

		//Permite começar o Id das contas em 1 ao invés de 0.
		public static int NumeroContas = 1;

		public Conta(int agencia, string nome, string cpf, TipoDeContas tipoConta)
		{
			Agencia = agencia;
			Nome = nome;
			CPF = cpf;
			Valor = 0;
			Tipo = tipoConta;

			IdConta = NumeroContas++;
		}

		public Conta(int agencia, string nome, string cpf, decimal valor, TipoDeContas tipoConta)
		{
			Agencia = agencia;
			Nome = nome;
			CPF = cpf;
			Valor = valor;
			Tipo = tipoConta;

			IdConta = NumeroContas++;
		}

		public virtual bool Sacar(decimal valor)
		{
			if(Valor > valor) // Se o valor da conta for maior que o valor do saque
			{
				Valor -= valor;
				return true;
			} 
			
			return false;
		}

		public bool Depositar(decimal valor)
		{
			Valor += valor;
			return true;
		}
		
		public virtual bool Depositar(decimal valor, Conta c)
		{
			if(c.Valor >= valor)
			{
				c.Valor -= valor;
				Valor += valor;
				return true;
			}

			return false;
		}

	}

	public enum TipoDeContas
	{
		Corrente,
		CorrenteEspecial,
		Poupança
	}
}
