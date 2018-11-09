using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;



public class DBAcces : MonoBehaviour {
	const string stringConnection =  @"Data Source=localhost;initial catalog=EOSDatabase;user id=sa;password=123456;";
	public static SqlConnection connection { get; set; }
	public static SqlCommand command { get; set; }
	public static SqlDataReader reader { get; set; }

	public static bool connect(string stringConnection){
		using (connection) {
			connection.ConnectionString = stringConnection;
			try {
				connection.Open ();
				return true;
			} catch (System.Exception ex) {
				//Log Error
				throw;
				return false;
			}
		}
	}

	public static void insert(string nome,string sobrenome,string email,string login,string senha){
		//insert command
	}
	public static void insert(int id,float posX,float posY,float posZ,float rotX,float rotY,float rotZ){
		//insert command Location
	}
	public static void insert(int id,int slot1,int slot2,int slot3,int slot4,int slot5,int slot6){
		//insert command Location
	}

	public static void update(int id,string nome,string sobrenome,string email,string login,string senha){
		//update command
	}

	public static void update(int id,float posX,float posY,float posZ,float rotX,float rotY,float rotZ){
		//update command Location
	}

	public static void insert(int id,int slot1,int slot2,int slot3,int slot4,int slot5,int slot6){
		//update command Location
	}

	public static void select(int id){
		//select command
	}

	public static void disconnect(){
		connection.Close ();
		connection.Dispose ();
	}
}
