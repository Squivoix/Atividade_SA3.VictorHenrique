using System;

namespace Atividade_SA3
{
	class Program
	{
		static void Main()
		{
			int cod;

			//Digite o código
			Console.WriteLine("Códigos:\n" +
				"1 - Adicionar Conta Corrente\n" +
				"2 - Adicionar Conta Corrente Especial\n" +
				"3 - Adicionar Conta Poupança\n" +
				"4 - Fechar Conta\n" +
				"5 - Sacar Dinheiro\n" +
				"6 - Depositar Dinheiro\n" +
				"7 - Visualizar Conta\n" +
				"9 - Sair");

			do
			{
				//Pede para escrever o número do código.
				Console.Write("\nDigite o número do código: ");

				//Enquanto não escrever um número, escreve uma mensagem de erro.
				while(!int.TryParse(Console.ReadLine(), out cod)) { Console.Write("Por favor, digite um número: "); }

				switch(cod)
				{
					case 1 : //Adicionar uma conta corrente.
					{
						string resp, nome, cpf; decimal valor;

						Console.Write("\nGostaria de depositar algum dinheiro? s/n: "); 
						resp = Console.ReadLine();

						Console.Write("Digite o nome da pessoa: "); nome = Console.ReadLine();
						Console.Write("Digite o CPF da pessoa: "); cpf = Console.ReadLine();

						if(resp == "s")
						{
							Console.Write("Digite o Valor que quer depositar: "); valor = decimal.Parse(Console.ReadLine());
							Menu.AdicionarConta(nome, cpf, valor, TipoDeContas.Corrente);
						} else if(resp == "n")
						{
							Menu.AdicionarConta(nome, cpf, TipoDeContas.Corrente);
						} else
						{
							Console.WriteLine("Ocorreu um erro ao adicionar a conta!");
						}
						
						break;
					}

					case 2 : //Adicionar uma conta corrente especial.
					{
						string resp, nome, cpf; decimal valor;

						Console.Write("\nGostaria de depositar algum dinheiro? s/n: ");
						resp = Console.ReadLine();

						Console.Write("Digite o nome da pessoa: "); nome = Console.ReadLine();
						Console.Write("Digite o CPF da pessoa: "); cpf = Console.ReadLine();

						if(resp == "s")
						{
							Console.Write("Digite o Valor que quer depositar: "); valor = decimal.Parse(Console.ReadLine());
							Menu.AdicionarConta(nome, cpf, valor, TipoDeContas.CorrenteEspecial);
						} else if(resp == "n")
						{
							Menu.AdicionarConta(nome, cpf, TipoDeContas.CorrenteEspecial);
						} else
						{
							Console.WriteLine("Ocorreu um erro ao adicionar a conta!");
						}

						break;
					}

					case 3 : //Adicionar uma conta poupança.
					{
						string resp, nome, cpf; decimal valor;

						Console.Write("\nGostaria de depositar algum dinheiro? s/n: ");
						resp = Console.ReadLine();

						Console.Write("Digite o nome da pessoa: "); nome = Console.ReadLine();
						Console.Write("Digite o CPF da pessoa: "); cpf = Console.ReadLine();

						if(resp == "s")
						{
							Console.Write("Digite o Valor que quer depositar: "); valor = decimal.Parse(Console.ReadLine());
							Menu.AdicionarConta(nome, cpf, valor, TipoDeContas.Poupança);
						} else if(resp == "n")
						{
							Menu.AdicionarConta(nome, cpf, TipoDeContas.Poupança);
						} else
						{
							Console.WriteLine("Ocorreu um erro ao adicionar a conta!");
						}

						break;
					}
					
					case 4 : //Fechar uma conta.
					{
						string cpf;
						Console.Write("\nDigite o número do CPF: "); cpf = Console.ReadLine();

						if(Menu.FecharConta(cpf))
						{
							Console.WriteLine($"Conta {cpf} fechada com sucesso!");
						} else
						{
							Console.WriteLine($"Ocorreu um erro ao fechar a conta {cpf}!");
						}

						break;
					}
					
					case 5 : //Sacar dinheiro.
					{
						string cpf;	decimal valor;
						Console.Write("\nDigite o número do CPF: "); cpf = Console.ReadLine();
						Console.Write("\nDigite quanto quer sacar: "); valor = decimal.Parse(Console.ReadLine());

						if(Menu.SacarDinheiro(cpf, valor))
						{
							Console.WriteLine($"Sacado R${valor} da conta {cpf} com sucesso!");
						} else
						{
							Console.WriteLine($"Dinheiro insuficiente!");
						}

						break;
					}
					
					case 6 : //Depositar dinheiro.
					{
						string resp, cpf1, cpf2; decimal valor;
						Console.Write("\nGostaria de fazer uma transferência? s/n: "); resp = Console.ReadLine();

						Console.Write("\nDigite seu CPF: "); cpf1 = Console.ReadLine();

						if(resp == "s")
						{
							Console.Write("Digite o CPF da pessoa que quer tranferir: "); cpf2 = Console.ReadLine();
							Console.Write("Digite quanto quer transferir: "); valor = decimal.Parse(Console.ReadLine());

							if(Menu.DepositarDinheiro(cpf1, cpf2, valor))
							{
								Console.WriteLine($"R${valor} transferido com sucesso de {cpf1} para {cpf2}!");
							} else
							{
								Console.WriteLine($"{cpf1} não possui dinheiro suficiente!");
							}
						} else if(resp == "n")
						{
							Console.Write("Digite quanto quer depositar: "); valor = decimal.Parse(Console.ReadLine());
							if(Menu.DepositarDinheiro(cpf1, valor))
							{
								Console.WriteLine($"R${valor} depositado com sucesso em {cpf1}!");
							} else
							{
								Console.WriteLine($"Ocorreu um erro ao depositar!");
							}
						} else
						{
							Console.WriteLine("Ocorreu um erro!");
						}

						break;
					}
					
					case 7 : //Visualizar conta.
					{
						string cpf;

						Console.Write("\nDigite seu CPF: "); cpf = Console.ReadLine();

						Menu.VisualizarConta(cpf);

						break;
					}

					default : //Código não existe.
					{
						Console.WriteLine("\nCódigo não existe!\n");
						break;
					}

				}

			} while(cod != 9);
			

			/*
			//Cria uma nova agencia e uma nova conta corrente.
			Agencia a1 = new ();
			ContaCorrente c1 = new (a1.NumeroAgencia, "Victor", "12345678911");

			//Escreve o número da agência.
			Console.WriteLine($"Número da Agência: {a1.NumeroAgencia}");

			//Adiciona uma conta corrente de cada forma possível.
			a1.AdicionarContaCorrente(c1);								//Adicionar a conta direto.
			a1.AdicionarContaCorrente("Lana", "12345678912");			//Nome e cpf, sem valor.
			a1.AdicionarContaCorrente("Janaína", "12345678913", 1500f);	//Nome e cpf, com valor.
			a1.AdicionarContaCorrente("Roberto", "12345678912");		//Tenta criar uma conta com um cpf já existente.

			//Mostra todos os valores de todas as contas.
			for(int i = 0; i < a1.Contas.Count; i++)
			{
				Console.WriteLine(
					$"\nNome da conta: {a1.Contas[i].Nome}\n" +
					$"CPF da conta: {a1.Contas[i].CPF}\n" +
					$"Agência da conta: {a1.Contas[i].Agencia}\n" +
					$"Número da conta: {a1.Contas[i].IdConta}\n" +
					$"Valor da conta: R${a1.Contas[i].Valor}");
			}

			//Fecha a conta c1.
			if(a1.FecharConta(c1))
			{
				Console.WriteLine($"\nConta {c1.Nome} fechada com sucesso!");
			} else
			{
				Console.WriteLine($"\nOcorreu um erro ao fechar a conta {c1.Nome}!");
			}

			//Deposita R$4500 em uma conta.
			if(a1.Contas[0].Depositar(4500f))
			{
				Console.WriteLine($"\nDepositado R$4500 com sucesso na conta {a1.Contas[0].Nome}!");
			} else
			{
				Console.WriteLine($"\nOcorreu um erro ao fechar a conta {a1.Contas[0].Nome}!");
			}

			//Faz a transferência de R$15 da conta 0 para a conta 1.
			if(a1.Contas[1].Depositar(15f, a1.Contas[0]))
			{
				Console.WriteLine($"\nTransferência de R$15 da conta {a1.Contas[0].Nome} para {a1.Contas[1].Nome} com sucesso!");
			} else
			{
				Console.WriteLine("\nOcorreu um erro na transferência!");
			}

			//Mostra todos os valores de todas as contas.
			for(int i = 0; i < a1.Contas.Count; i++)
			{
				Console.WriteLine(
					$"\nNome da conta: {a1.Contas[i].Nome}\n" +
					$"CPF da conta: {a1.Contas[i].CPF}\n" +
					$"Agência da conta: {a1.Contas[i].Agencia}\n" +
					$"Número da conta: {a1.Contas[i].IdConta}\n" +
					$"Valor da conta: R${a1.Contas[i].Valor}");
			}

			//Tenta fazer uma transferência de R$10.000 da conta Lana para Janaína.
			if(a1.Contas[1].Depositar(10000f, a1.Contas[0]))
			{
				Console.WriteLine($"\nTransferência de R$15 da conta {a1.Contas[0].Nome} para {a1.Contas[1].Nome} com sucesso!");
			} else
			{
				Console.WriteLine("\nOcorreu um erro na transferência!");
			}
			*/
		}
	}
}
