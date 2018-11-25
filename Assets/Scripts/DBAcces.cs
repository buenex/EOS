using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using UnityEngine;
using System.Text;
using System.Data;

public class DBAcces : MonoBehaviour {
	
	static string stringConnection =  @"Data Source=127.0.0.1;initial catalog=EOSDatabase;user id=sa;password=123456;";//Definição da string de conexão, onde é definido a database que será usada , o login de acesso, e a senha
	private static SqlConnection connection;//declaração de um objeto estático (que não necessita ser instanciado) do tipo sqlConnection
	public static SqlDataReader reader { get; set; } // Propriedade de reader, leitor de dados do banco de dados

	public static bool connect(){		//inicio do metodo connect, onde abrirá conexao com o banco de dados
		connection.ConnectionString = stringConnection;//atribuindo ao objeto de conexao, as informações para acesso do banco de dados

		try {//estrutura que tentara fazer todos os comandos dentro de seu bloco
			connection.Open (); //tenta abrir conexao
			return true; // se deu para abrir, ele retornara verdadeiro

		} catch (System.Exception ex) {//se nao abrir a conexão ele cairá no CATCH e pegará um erro (excecao)
			Log.gravar(ex);//está gravando esse erro em um arquivo dentro do nosso jogo
			return false;//e retorna o valor de falso para mostrar que nao conseguiu abrir conexao
		}
	}

	#region Insert

	public static void insert(string nome,string sobrenome,string email,string login,string senha){ //metodo para inserir dados do jogador no banco de dados
		if (connect()) {//chamada do metodo connect para testar se conseguiu abrir conexao
			StringBuilder sql = new StringBuilder ();//instancia de um objeto string builder, que é basicamente um construtor de texto

			using (SqlCommand command = new SqlCommand ()) { //usando um novo slq command, que serve para executar as aḉões no banco de dados
				
				command.Connection = connection;//passando para o command onde ele irá executar os comandos SQL

				sql.Append ("INSERT INTO Jogador "); //colocando no string builder uma parte do comando SQL
				sql.Append ("VALUES (@nome,@sobrenome,@email,@login,@senha)"); //e juntando com a segunda parte do comando, com alguns parametros (@nome) etc.

				command.CommandText = sql.ToString ();//passando para o comando , o que ele executara no SQL,porem não executa ainda

				command.Parameters.Add ("@nome", System.Data.SqlDbType.VarChar, 50).Value = nome; //adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@sobrenome", System.Data.SqlDbType.VarChar, 50).Value = sobrenome; //adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@login", System.Data.SqlDbType.VarChar, 15).Value = login; //adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@senha", System.Data.SqlDbType.VarChar, 30).Value = senha; //adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@email", System.Data.SqlDbType.VarChar, 80).Value = email; //adicionando o parametro passado na string acima com valor passado no parametro desse metodo

				try {//tentara fazer os comandos dentro desse bloco
					command.ExecuteNonQuery (); //aqui ele executara o comando dentro do SQL

					sql = new StringBuilder (); //novo objeto string builder vazio

					sql.Append ("INSERT INTO Location VALUES('"+login+"',0,1,0,0,0,0)");  //colocando no string builder uma parte do comando SQL
					 
					command.CommandText = sql.ToString(); //passando para o command o que ele executara
					command.ExecuteNonQuery(); //aqui ele executa o comando que passamos acima

					sql = new StringBuilder();//novo objeto string builder vazio

					sql.Append ("INSERT INTO Inventory VALUES('"+login+"',7,7,7,7,7,7,1)");//colocando no string builder uma parte do comando SQL

					command.CommandText = sql.ToString();//passando para o command o que ele executara
					command.ExecuteNonQuery();//aqui ele executa o comando que passamos acima

				} catch (SqlException ex) {//se nao abrir a conexão ele cairá no CATCH e pegará um erro (excecao)
					Log.gravar (ex);//está gravando esse erro em um arquivo dentro do nosso jogo
				}
			}
		} else { //se não houve conexão ele cairá aqui
			Debug.Log ("Nao teve conexao");
		}
	}
	#endregion

	#region Update

	public static void update(int id,float posX,float posY,float posZ,float rotX,float rotY,float rotZ){ //metodo para atualizar dados da localizacao no banco de dados
		if (connect()) {//chamada do metodo connect para testar se conseguiu abrir conexao
			StringBuilder sql = new StringBuilder ();//instancia de um objeto string builder, que é basicamente um construtor de texto
			using (SqlCommand command = new SqlCommand ()) {//usando um novo slq command, que serve para executar as aḉões no banco de dados
				command.Connection = connection;//passando para o command onde ele irá executar os comandos SQL

				sql.Append ("UPDATE Location ");//colocando no string builder uma parte do comando SQL
				sql.Append ("SET posX = @posX,");//e juntando com essa  parte do comando, com alguns parametros (@nome) etc.
				sql.Append ("    posY = @posY,");//e juntando com essa  parte do comando, com alguns parametros (@nome) etc.
				sql.Append ("    posZ = @posZ,");//e juntando com essa  parte do comando, com alguns parametros (@nome) etc.
				sql.Append ("    rotX = @rotX,");//e juntando com essa  parte do comando, com alguns parametros (@nome) etc.
				sql.Append ("    rotY = @rotY,");//e juntando com essa  parte do comando, com alguns parametros (@nome) etc.
				sql.Append ("    rotZ = @rotZ) ");//e juntando com essa  parte do comando, com alguns parametros (@nome) etc.
				sql.Append ("WHERE id = @id");//e juntando com essa  parte do comando, com alguns parametros (@nome) etc.

				command.CommandText = sql.ToString ();//passando para o command o que ele executara

				command.Parameters.Add ("@id", System.Data.SqlDbType.Int).Value = id;//adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@posX", System.Data.SqlDbType.Float).Value = posX;//adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@posY", System.Data.SqlDbType.Float).Value = posY;//adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@posZ", System.Data.SqlDbType.Float).Value = posZ;//adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@rotX", System.Data.SqlDbType.Float).Value = rotX;//adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@rotY", System.Data.SqlDbType.Float).Value = rotY;//adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@rotZ", System.Data.SqlDbType.Float).Value = rotZ;//adicionando o parametro passado na string acima com valor passado no parametro desse metodo

				try {//tentara fazer os comandos dentro desse bloco
					command.ExecuteNonQuery ();//aqui ele executara o comando dentro do SQL
				} catch (SqlException ex) {//se nao abrir a conexão ele cairá no CATCH e pegará um erro (excecao)
					//Log error
					Log.gravar (ex);//está gravando esse erro em um arquivo dentro do nosso jogo
				}
			}
		}else {//se não houve conexão ele cairá aqui
			Debug.Log ("Nao teve conexao");
		}
		//update command Location
	}

	public static void update(int id,int slot1,int slot2,int slot3,int slot4,int slot5,int slot6,float flashLight){//metodo para inserir dados do inventario no banco de dados
		if (connect()) {//chamada do metodo connect para testar se conseguiu abrir conexao
			StringBuilder sql = new StringBuilder ();//instancia de um objeto string builder, que é basicamente um construtor de texto
			using (SqlCommand command = new SqlCommand ()) {//usando um novo slq command, que serve para executar as aḉões no banco de dados
				command.Connection = connection;//passando para o command onde ele irá executar os comandos SQL

				sql.Append ("UPDATE Inventory ");//colocando no string builder uma parte do comando SQL
				sql.Append ("SET slot1 = @slot1,");//e juntando com essa  parte do comando, com alguns parametros (@nome) etc.
				sql.Append ("slot2 = @slot2,");//e juntando com essa  parte do comando, com alguns parametros (@nome) etc.
				sql.Append ("slot3 = @slot3,");//e juntando com essa  parte do comando, com alguns parametros (@nome) etc.
				sql.Append ("slot4 = @slot4,");//e juntando com essa  parte do comando, com alguns parametros (@nome) etc.
				sql.Append ("slot5 = @slot5,");//e juntando com essa  parte do comando, com alguns parametros (@nome) etc.
				sql.Append ("slot6 = @slot6,");//e juntando com essa  parte do comando, com alguns parametros (@nome) etc.
				sql.Append ("flashLight = @flashLight) ");//e juntando com essa  parte do comando, com alguns parametros (@nome) etc.
				sql.Append ("WHERE id = @id");//e juntando com essa  parte do comando, com alguns parametros (@nome) etc.

				command.CommandText = sql.ToString ();//passando para o command o que ele executara

				command.Parameters.Add ("@id", System.Data.SqlDbType.Int).Value = id;//adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@slot1", System.Data.SqlDbType.Int).Value = slot1;//adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@slot2", System.Data.SqlDbType.Int).Value = slot2;//adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@slot3", System.Data.SqlDbType.Int).Value = slot3;//adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@slot4", System.Data.SqlDbType.Int).Value = slot4;//adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@slot5", System.Data.SqlDbType.Int).Value = slot5;//adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@slot6", System.Data.SqlDbType.Int).Value = slot6;//adicionando o parametro passado na string acima com valor passado no parametro desse metodo
				command.Parameters.Add ("@flashLight", System.Data.SqlDbType.Float).Value = flashLight;//adicionando o parametro passado na string acima com valor passado no parametro desse metodo

				try {//tentara fazer os comandos dentro desse bloco
					command.ExecuteNonQuery ();//aqui ele executara o comando dentro do SQL
				} catch (SqlException ex) {//se nao abrir a conexão ele cairá no CATCH e pegará um erro (excecao)
					//Log error
					Log.gravar (ex);//está gravando esse erro em um arquivo dentro do nosso jogo
				}
			}
		}else {//se não houve conexão ele cairá aqui
			Debug.Log ("Nao teve conexao");
		}
		//update command Location
	}

	#endregion

	public static bool login(string login){//metodo para logar o jogador e carregar o load do jogo
		if (connect()) {//chamada do metodo connect para testar se conseguiu abrir conexao
			StringBuilder sql = new StringBuilder ();//instancia de um objeto string builder, que é basicamente um construtor de texto
			using (SqlCommand command = new SqlCommand ()) {//usando um novo slq command, que serve para executar as aḉões no banco de dados
				command.Connection = connection;//passando para o command onde ele irá executar os comandos SQL

				sql.Append ("SELECT J.id,");								//colocando no string builder uma parte do comando SQL
				sql.Append ("       J.login,");								//e juntando com essa  parte do comando
				sql.Append ("       L.posX as lposx,");						//e juntando com essa  parte do comando
				sql.Append ("       L.posY as lposy,");						//e juntando com essa  parte do comando
				sql.Append ("       L.posZ as lposz,");						//e juntando com essa  parte do comando
				sql.Append ("       L.rotX as lrotx,");						//e juntando com essa  parte do comando
				sql.Append ("       L.rotY as lroty,");						//e juntando com essa  parte do comando
				sql.Append ("       L.rotZ as lrotz,");						//e juntando com essa  parte do comando
				sql.Append ("       I.slot1 as islot1,");					//e juntando com essa  parte do comando
				sql.Append ("       I.slot2 as islot2,");					//e juntando com essa  parte do comando
				sql.Append ("       I.slot3 as islot3,");					//e juntando com essa  parte do comando
				sql.Append ("       I.slot4 as islot4,");					//e juntando com essa  parte do comando
				sql.Append ("       I.slot5 as islot5,");					//e juntando com essa  parte do comando
				sql.Append ("       I.slot6 as islot6,");					//e juntando com essa  parte do comando
				sql.Append ("       I.flashLight as iFlashLight ");			//e juntando com essa  parte do comando
				sql.Append ("FROM Jogador as J ");							//e juntando com essa  parte do comando
				sql.Append ("INNER JOIN Location L ON L.login = J.login "); //e juntando com essa  parte do comando
				sql.Append ("INNER JOIN Inventory I ON I.login = L.login ");//e juntando com essa  parte do comando
				sql.Append ("WHERE J.login = '"+login+"'");

				command.CommandText = sql.ToString ();						//passando para o command o que ele executara

				try {														//tentara fazer os comandos dentro desse bloco
					reader = command.ExecuteReader();						//aqui ele está atribuindo um comando de leitura de dados do banco e trazendo o resultado para a propriedade de SqlDataReader que colocamos no inicio do codigo
					if(reader.Read()){										//aqui ele testa se o leitor está lendo algo,
						if(reader.HasRows){									//aqui ele testa se o leitor encontrou dados no banco de dados
							GameController.LoginPlayer=reader["login"].ToString();  //aqui ele esta pegando valor do leitor e atribuindo a uma propriedade do script game controller onde salva o login do jogador
							GameController.IdPlayer = (int)reader["id"];			//aqui ele esta pegando valor do leitor e atribuindo a uma propriedade do script game controller onde salva o id do jogador
							Location.location = new Vector3((float)((double)reader["lposx"]),(float)((double)reader["lposy"]),(float)((double)reader["lposz"])); 		//aqui ele esta pegando valor do leitor e atribuindo a uma propriedade do script game controller onde salva a posicao do jogador
							Location.Rotation = new Vector3((float)((double)reader["lrotx"]),(float)((double)reader["lroty"]),(float)((double)reader["lrotz"]));		//aqui ele esta pegando valor do leitor e atribuindo a uma propriedade do script game controller onde salva a rotacao do jogador
							Inventory.itens=new int[6];										//aqui ele esta definindo uma lista com 6 espaços que armazenam numeros inteiros
							Inventory.itens[0] = (int)reader["islot1"];   					//aqui ele esta pegando valor do leitor e atribuindo a um espaco da lista que definimos acima
							Inventory.itens[1] = (int)reader["islot2"];						//aqui ele esta pegando valor do leitor e atribuindo a um espaco da lista que definimos acima
							Inventory.itens[2] = (int)reader["islot3"];						//aqui ele esta pegando valor do leitor e atribuindo a um espaco da lista que definimos acima
							Inventory.itens[3] = (int)reader["islot4"];						//aqui ele esta pegando valor do leitor e atribuindo a um espaco da lista que definimos acima
							Inventory.itens[4] = (int)reader["islot5"];						//aqui ele esta pegando valor do leitor e atribuindo a um espaco da lista que definimos acima
							Inventory.itens[5] = (int)reader["islot6"];						//aqui ele esta pegando valor do leitor e atribuindo a um espaco da lista que definimos acima
							Inventory.flashLight = (float)((double)reader["iFlashLight"]);  //aqui ele esta pegando valor do leitor e atribuindo a um espaco da lista que definimos acima
						
							return true; 	//retorno de um valor verdadeiro, que é de login encontrado
						}else{				//se ele nao encontrar dados nenhum
							return false;	//ira retornar um valor falso
						}	
					}
				} catch (SqlException ex) { //se nao abrir a conexão ele cairá no CATCH e pegará um erro (excecao)
					Log.gravar (ex);        //está gravando esse erro em um arquivo dentro do nosso jogo
					return false;//ira retornar um valor falso
				}
			}
		}
		return false;//ira retornar um valor falso
	}

	public static void disconnect(){ //metodo de disconnect 
		connection.Close (); //corta a conexao com o banco
		connection.Dispose (); //libera a conexao para ser retirada de memoria
	}
}

/* ===============================================================================================================================================
 * ============================================ DIFERENCAS ENTRE CLOSE E DISPOSE =================================================================
 * ===============================================================================================================================================
 * ======= CLOSE ======== APENAS CORTA CONEXAO COM BANCO DE DADOS POREM ELE PERMANECE EM MEMORIA =================================================
 * ===============================================================================================================================================
 * ======= DISPOSE ====== LIBERA A CONEXAO PARA SER REMOVIDA DE MEMORIA ==========================================================================
 * ===============================================================================================================================================
 * ===============================================================================================================================================
 * ===============================================================================================================================================
 * ======= EXECUTENONQUERY ========== EXECUTA COMANDOS QUE NAO PEGAM DADOS, COMO O INSERT, UPDATE, DELETE ========================================
 * ===============================================================================================================================================
 * ========EXECUTEREADER ============= EXECUTA COMANDO QUE PEGAM DADOS DO BANCO DE DADOS COMO O COMANDO SELECT ===================================
 * ===============================================================================================================================================*/
