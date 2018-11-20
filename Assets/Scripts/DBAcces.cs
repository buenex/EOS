using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using UnityEngine;
using System.Text;



public class DBAcces : MonoBehaviour {
	static string stringConnection =  @"Data Source=127.0.0.1;initial catalog=EOSDatabase;user id=sa;password=123456;";
	private static SqlConnection connection;
	//public static SqlCommand command { get; set; }
	public static SqlDataReader reader { get; set; }

	public void Awake(){
		

//		
	}

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
					Debug.Log ("inseriu");
				} catch (SqlException ex) {
					Log.gravar (ex);
					Debug.Log ("nao inseriu " + ex.Message);
				}
			}
		} else {
			Debug.Log ("Nao teve conexao");
		}
	}
	public static void insert(int id,float posX,float posY,float posZ,float rotX,float rotY,float rotZ){
		if (connect()) {
			StringBuilder sql = new StringBuilder ();
			using (SqlCommand command = new SqlCommand ()) {
				command.Connection = connection;

				sql.Append ("INSERT INTO Location ");
				sql.Append ("VALUES (@id,@posX,@posY,@posZ,@rotX,@rotY,@rotZ) ");
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
					Debug.Log ("inseriu");
				}
			}
		}else {
				Debug.Log ("Nao teve conexao");
			}
		//insert command Location
	}
	public static void insert(int id,int slot1,int slot2,int slot3,int slot4,int slot5,int slot6,float flashLight){
		if (connect()) {
			StringBuilder sql = new StringBuilder ();
			using (SqlCommand command = new SqlCommand ()) {
				command.Connection = connection;

				sql.Append ("INSERT INTO Inventory ");
				sql.Append ("VALUES (@id,@slot1,@slot2,@slot3,@slot4,@slot5,@slot6,@flashLight)");
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
					Debug.Log ("inseriu");
				}
			}
		}else {
			Debug.Log ("Nao teve conexao");
		}
		//insert command Location
	}
	#endregion

	#region Update

	public static void update(int id,string nome,string sobrenome,string email,string login,string senha){
		if (connect()) {
			StringBuilder sql = new StringBuilder ();
			using (SqlCommand command = new SqlCommand ()) {
				command.Connection = connection;

				sql.Append ("UPDATE Player ");
				sql.Append ("SET nome = @nome,");
				sql.Append ("sobrenome = @sobrenome,");
				sql.Append ("email = @email,");
				sql.Append ("login = @login,");
				sql.Append ("senha = @senha) ");
				sql.Append ("WHERE id = @id");

				command.CommandText = sql.ToString ();

				command.Parameters.Add ("@nome", System.Data.SqlDbType.VarChar, 50).Value = nome;
				command.Parameters.Add ("@sobrenome", System.Data.SqlDbType.VarChar, 50).Value = sobrenome;
				command.Parameters.Add ("@login", System.Data.SqlDbType.VarChar, 15).Value = login;
				command.Parameters.Add ("@senha", System.Data.SqlDbType.VarChar, 30).Value = senha;
				command.Parameters.Add ("@email", System.Data.SqlDbType.VarChar, 80).Value = email;

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
		//update command
	}

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

	public static void select(int id,string table){
		if (connect()) {
			StringBuilder sql = new StringBuilder ();
			using (SqlCommand command = new SqlCommand ()) {
				command.Connection = connection;

				sql.Append ("SELECT * FROM " + table + " WHERE id = "+id);
				command.CommandText = sql.ToString ();
				reader = command.ExecuteReader ();
			}
		}
		//select command
	}
	public static void select(string login){
		if (connect()) {
			StringBuilder sql = new StringBuilder ();
			using (SqlCommand command = new SqlCommand ()) {
				command.Connection = connection;
				sql.Append ("SELECT * FROM Jogador WHERE login = '"+login+"'");
				command.CommandText = sql.ToString ();
				try {
					using (SqlDataReader rd = command.ExecuteReader ()) {
						reader = rd;
						Debug.Log (rd.HasRows);
						//GameController.IdPlayer = (int)rd.GetValue(0);
						//GameController.LoginPlayer = rd.GetValue(1).ToString();
					}
				} catch (System.Exception ex) {
					Debug.Log (ex);
				}

			}
		}
		//select command
	}

	public static void disconnect(){
		connection.Close ();
		connection.Dispose ();
	}
}
