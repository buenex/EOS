using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {
	public Text Message;
	public InputField nome;
	public InputField sobrenome;
	public InputField email;
	public InputField Login;
	public InputField senha;
	public InputField confirmarSenha;
	public InputField loginUsuario;
	public InputField senhaUsuario;

	public void Cadastro(){
		if (senha.text == confirmarSenha.text) {
			DBAcces.insert (nome.text, sobrenome.text, email.text, Login.text, senha.text);
			Message.text = "cadastrado com sucesso";
		} else {
			Message.text = "As senhas digitadas não batem";
		}
	}
	public void login(){
		if (DBAcces.login (loginUsuario.text)) {
			Message.text = "Logado com sucesso!";
		}
	}

	public void loadScene(string nameScene){
		SceneManager.LoadScene (nameScene);
	}
}
