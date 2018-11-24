using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using UnityEngine;
using System.Text;
using System.Data;



public class DBAcces : MonoBehaviour {
	static string stringConnection =  @"Data Source=127.0.0.1;initial catalog=EOSDatabase;user id=sa;password=123456;";
	private static SqlConnection connection;
	public static SqlDataReader reader { get; set; }

	public static bool connect(){
		//command.Connection = connection;
		 SqlConnection conn = new SqlConnection (stringConnection);
		//Debug.Log (conn.ConnectionString);
		//conn.Open ();

		try {
			conn.Open ();
			connection = conn;
			//Debug.Log("conectou");
			return true;

		} catch (System.Exception ex) {
			//Log Error
			Log.gravar(ex);
//			Debug.Log(connection.State);
		//	Debug.Log(conn.State);
			return false;


		}
	}

	#region Insert
	public static void insert(string nome,string sobrenome,string email,string login,string senha){
		if (connect()) {
			StringBuilder sql = new StringBuilder ();

			using (SqlCommand command = new SqlCommand ()) {
				
				command.Connection = connection;

				sql.Append ("INSERT INTO Jogador ");
				sql.Append ("VALUES (@nome,@sobrenome,@email,@login,@senha)");

				command.CommandText = sql.ToString ();

				command.Parameters.Add ("@nome", System.Data.SqlDbType.VarChar, 50).Value = nome;
				command.Parameters.Add ("@sobrenome", System.Data.SqlDbType.VarChar, 50).Value = sobrenome;
				command.Parameters.Add ("@login", System.Data.SqlDbType.VarChar, 15).Value = login;
				command.Parameters.Add ("@senha", System.Data.SqlDbType.VarChar, 30).Value = senha;
				command.Parameters.Add ("@email", System.Data.SqlDbType.VarChar, 80).Value = email;

				try {
					command.ExecuteNonQuery ();

					sql = new StringBuilder ();

					sql.Append ("INSERT INTO Location VALUES('"+login+"',0,0,0,0,0,0)");

					command.CommandText = sql.ToString();
					command.ExecuteNonQuery();

					sql = new StringBuilder();

					sql.Append ("INSERT INTO Inventory VALUES('"+login+"',0,0,0,0,0,0,1)");

					command.CommandText = sql.ToString();
					command.ExecuteNonQuery();

				} catch (SqlException ex) {
					Log.gravar (ex);
					Debug.Log ("nao inseriu " + ex.Message);
				}
			}
		} else {
			Debug.Log ("Nao teve conexao");
		}
	}
	#endregion

	#region Update

	public static void update(int id,float posX,float posY,float posZ,float rotX,float rotY,float rotZ){
		if (connect()) {
			StringBuilder sql = new StringBuilder ();
			using (SqlCommand command = new SqlCommand ()) {
				command.Connection = connection;

				sql.Append ("UPDATE Location ");
				sql.Append ("SET posX = @posX,");
				sql.Append ("posY = @posY,");
				sql.Append ("posZ = @posZ,");
				sql.Append ("rotX = @rotX,");
				sql.Append ("rotY = @rotY,");
				sql.Append ("rotZ = @rotZ) ");
				sql.Append ("WHERE id = @id");

				command.CommandText = sql.ToString ();

				command.Parameters.Add ("@id", System.Data.SqlDbType.Int).Value = id;
				command.Parameters.Add ("@posX", System.Data.SqlDbType.Float).Value = posX;
				command.Parameters.Add ("@posY", System.Data.SqlDbType.Float).Value = posY;
				command.Parameters.Add ("@posZ", System.Data.SqlDbType.Float).Value = posZ;
				command.Parameters.Add ("@rotX", System.Data.SqlDbType.Float).Value = rotX;
				command.Parameters.Add ("@rotY", System.Data.SqlDbType.Float).Value = rotY;
				command.Parameters.Add ("@rotZ", System.Data.SqlDbType.Float).Value = rotZ;

				try {
					command.ExecuteNonQuery ();
				} catch (SqlException ex) {
					//Log error
					Log.gravar (ex);
				}
			}
		}else {
			Debug.Log ("Nao teve conexao");
		}
		//update command Location
	}

	public static void update(int id,int slot1,int slot2,int slot3,int slot4,int slot5,int slot6,float flashLight){
		if (connect()) {
			StringBuilder sql = new StringBuilder ();
			using (SqlCommand command = new SqlCommand ()) {
				command.Connection = connection;

				sql.Append ("UPDATE Inventory ");
				sql.Append ("SET slot1 = @slot1,");
				sql.Append ("slot2 = @slot2,");
				sql.Append ("slot3 = @slot3,");
				sql.Append ("slot4 = @slot4,");
				sql.Append ("slot5 = @slot5,");
				sql.Append ("slot6 = @slot6,");
				sql.Append ("flashLight = @flashLight) ");
				sql.Append ("WHERE id = @id");

				command.CommandText = sql.ToString ();

				command.Parameters.Add ("@id", System.Data.SqlDbType.Int).Value = id;
				command.Parameters.Add ("@slot1", System.Data.SqlDbType.Int).Value = slot1;
				command.Parameters.Add ("@slot2", System.Data.SqlDbType.Int).Value = slot2;
				command.Parameters.Add ("@slot3", System.Data.SqlDbType.Int).Value = slot3;
				command.Parameters.Add ("@slot4", System.Data.SqlDbType.Int).Value = slot4;
				command.Parameters.Add ("@slot5", System.Data.SqlDbType.Int).Value = slot5;
				command.Parameters.Add ("@slot6", System.Data.SqlDbType.Int).Value = slot6;
				command.Parameters.Add ("@flashLight", System.Data.SqlDbType.Float).Value = flashLight;

				try {
					command.ExecuteNonQuery ();
				} catch (SqlException ex) {
					//Log error
					Log.gravar (ex);
				}
			}
		}else {
			Debug.Log ("Nao teve conexao");
		}
		//update command Location
	}

	#endregion

	public static bool login(string login){
		if (connect()) {
			StringBuilder sql = new StringBuilder ();
			using (SqlCommand command = new SqlCommand ()) {
				command.Connection = connection;
				command.CommandText = sql.ToString ();
				sql.Append ("SELECT J.id,");
				sql.Append ("       J.login,");
				sql.Append ("       L.posX as lposx,");
				sql.Append ("       L.posY as lposy,");
				sql.Append ("       L.posZ as lposz,");
				sql.Append ("       L.rotX as lrotx,");
				sql.Append ("       L.rotY as lroty,");
				sql.Append ("       L.rotZ as lrotz,");
				sql.Append ("       I.slot1 as islot1,");
				sql.Append ("       I.slot2 as islot2,");
				sql.Append ("       I.slot3 as islot3,");
				sql.Append ("       I.slot4 as islot4,");
				sql.Append ("       I.slot5 as islot5,");
				sql.Append ("       I.slot6 as islot6,");
				sql.Append ("       I.flashLight as iFlashLight ");
				sql.Append ("FROM Jogador as J ");
				sql.Append ("INNER JOIN Location L ON L.login = J.login ");
				sql.Append ("INNER JOIN Inventory I ON I.login = L.login ");
				sql.Append ("WHERE J.login = '"+login+"'");

				command.CommandText = sql.ToString ();

				try {							
					Debug.Log ("entrou Try");
					reader = command.ExecuteReader();
					if(reader.Read()){
						Debug.Log ("try - read");
							if(reader.HasRows){
							Debug.Log ("try - read - hasRows");
							GameController.LoginPlayer=reader["login"].ToString();
							GameController.IdPlayer = (int)reader["id"];
							Location.location = new Vector3((float)((double)reader["lposx"]),(float)((double)reader["lposy"]),(float)((double)reader["lposz"]));
							Location.Rotation = new Vector3((float)((double)reader["lrotx"]),(float)((double)reader["lroty"]),(float)((double)reader["lrotz"]));
							Inventory.itens=new int[6];
							Inventory.itens[0] = (int)reader["islot1"];
							Inventory.itens[1] = (int)reader["islot2"];
							Inventory.itens[2] = (int)reader["islot3"];
							Inventory.itens[3] = (int)reader["islot4"];
							Inventory.itens[4] = (int)reader["islot5"];
							Inventory.itens[5] = (int)reader["islot6"];
							Inventory.flashLight = (float)((double)reader["iFlashLight"]);

							return true;
						}else{
							Debug.Log ("else HasRows");
							return false;
						}	
					}
				} catch (SqlException ex) {
				Debug.Log ("catch  "+ex);
				//Log.gravar (ex);
				return false;
			}
		}
	}
	return false;
}

	public static void disconnect(){
		connection.Close ();
		connection.Dispose ();
	}
}
