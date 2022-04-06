/**
* ========================================================================================
* File:		PlayerMovement.cs
* Author: 	Philipp Hermann
* Brief: 	this script handles user input, basic player movement and the connected animations.
* Date: 	06.04.2022
* Version: 	1.0
* ========================================================================================
* Licenced under the GNU general public licence v3.0
**/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//"using" ist in C# das, was in C++ "include" heißt, es wird also ein Paket oder ein anderes Dokument eingebunden.

public class PlayerMovement : MonoBehaviour{
    
    public CharacterController2D controller; 
    //Dieses Skript greift auf das Skript "CharacterController2D" unter dem Namen "controller" zu.
    public Animator animator;
    //Dieses Skript greift auf einen Animator unter dem namen "animator" zu.

    public float runSpeed = 40f;
    /*
    die Variable "runSpeed" ist schon im CharacterController2D definiert (deshalb hier "public"). 
    Das f hinter 40 stellt sicher, dass auch wirklich ein Fließkommawert gespeichert wird und kein integer.
    */

    float horizontalMove = 0f;
    /*
    diese Variable speichert später einen Wert, der der Spieleengine sagt, in welche Richtung 
    die Spielfigur wie schnell bewegt werden soll.
    */

    bool jump = false;
    //unter dieser Variable wird gespeichert, ob gerade gesprungen werden soll (true) oder nicht (false).

    bool crouch = false;
    //hier wird gespeichert, ob gerade gekrochen wird oder nicht.

    void Start(){
        //wird ausgeführt, wenn das Objekt, auf das sich dieses Skript bezieht, erstellt wird. Wird in diesem Fall nicht benötigt.
    }
    
    void Update(){ //wird jedes Frame einmal ausgeführt (im Normalfall 25 mal pro Sekunde)
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        /*
        In der Variablen "horizontalMove" wird das Ergebnis einer Multiplikation gespeichert. 
        Dieses ergibt sich aus dem Wert von "Input.GetAxisRaw("Horizontal")", dieser ist:
         0, wenn nichts gedrückt wird;
         1, wenn "d" oder "->" gedrückt werden;
        -1, wenn "a" oder "<-" gedrückt werden,
        und der runSpeed, die in Zeile 11 auf 40 festgelegt wurde.
        */

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        //die Animator-Variable "Speed" soll auf den Betrag von horizontalMove gesetzt werden.

        if(Input.GetButtonDown("Jump")){    //wenn der unter "Jump" gespeicherte Knopf gedrückt wird...
            jump = true;                    //soll die Variable "jump" auf 1 gesetzt werden...
            animator.SetBool("IsJumping", true); //...und die Animator-Variable "IsJumping" soll wahr sein.
        }

        if(Input.GetButtonDown("Crouch")){      //wenn der unter "Crouch" gespeicherte Knopf gedrückt wird...
            crouch = true;                      //soll die variable "crouch" auf 1 gesetzt werden...
        }
        else if (Input.GetButtonUp("Crouch")){  //wenn der unter "Crouch" gespeicherte Knopf wieder losgelassen wird...
            crouch = false;                     //soll die Variable "crouch" auf 0 gesetzt werden...
        }
    }

    public void OnLanding(){
        //Diese Funktion wird immer aufgerufen, wenn der Charakter landet, also der groundcheck von false auf true wechselt.
        animator.SetBool("IsJumping", false); //Beim Landen soll die Animator-Variable "IsJumping" wieder auf false gesetzt werden.
    }

    public void OnCrouching(bool IsCrouching){
        //Diese Funktion wird immer ausgeführt, wenn der Charakter schleicht
        animator.SetBool("IsCrouching", crouch); /*hier kann die Variable "crouch" verwendet werden, weil diese durch die if-else if-Bedingung in
        Update() schon den gewünschten Wert erhält.*/
    }

    void FixedUpdate(){ //wird ungefähr 50 mal pro Sekunde aufgerufen, hier kommt alles rein, was direkt Körper betrifft, die von Physik beeinflusst werden.
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        /*
        Die Funktion "Move" aus dem CharacterController2D bewegt die Spielfigur, die Übergebenen Werte sagen der Funktion, wie:
        1. als erster Parameter der Wert von horizontalMove übergeben, "Time.fixedDeltaTime" ist das Intervall,
           in dem die Physik geupdated wird. Das sagt der Funktion Move, wie schnell der Charakter nach rechts oder links
           bewegt werden soll.
        2. als zweiter Parameter wird "crouch" übergeben, also entweder 1 für kriechen oder 0 für nicht kriechen.
        3. als dritter Parameter wird "jump" übergeben, also entweder 1 für springen oder 0 für nicht springen.
        */
        jump = false; //"jump" muss noch von true auf false zurückgesetzt werden, da sonst dauerhaft gesprungen werden würde.
    }
}