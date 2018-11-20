using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
	public Text Message;
	public InputField nome;
	public InputField sobrenome;
	public InputField email;
	public InputField login;
	public InputField senha;
	public InputField confirmarSenha;

	public void logar(){
		if (senha.text == confirmarSenha.text) {
			DBAcces.insert (nome.text, sobrenome.text, email.text, login.text, senha.text);
		} else {
			Message.text = "As senhas digitadas não batem";
		}
	}
}
