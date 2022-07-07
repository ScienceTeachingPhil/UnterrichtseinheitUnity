/**
* ========================================================================================
* File:		PlayerMovementAufgabe_v1.0.cs
* Author: 	Philipp Hermann
* Brief: 	this script handles user input and basic player movement. It is not working without some tasks solved!
* Date: 	07.07.2022
* Version: 	1.0
* ========================================================================================
* Licenced under the GNU general public licence v3.0
**/









/*
==========================================TODO===================================================
Definiere unter den Erklärungstexten die entsprechenden Variablen, Schleifen oder Gleichungen.
Alle Aufgaben sind (wie dieser Text) mit doppelten Linien umschlossen, damit du sie besser findest.
==========================================TODO===================================================
*/









using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//"using" ist in C# das, was in C++ "include" heißt, es wird also ein Paket oder ein anderes Dokument eingebunden.

/*
Es wird hier eine Klasse namens "PlayerMovement" erstellt. Da die Klasse "public" ist, können im Unity Editor
einige Werte verändert werden und die Unity Engine kann beim ausführen des Spiels auf Funktionen aus dieser Klasse zugreifen.
*/
public class PlayerMovement : MonoBehaviour{
    
    public CharacterController2D controller; 
    //Dieses Skript greift auf das Skript "CharacterController2D" unter dem Namen "controller" zu.
 
    /*
    =================================================================================================
    Eine Variable runSpeed soll Kommazahlen speichern und mit dem Wert 40 initialisiert werden. 
    Die Variable muss public sein, damit auch der CharacterController2D darauf zugreifen kann.
    =================================================================================================
    */
    //HIER EINFÜGEN

    /*
    ====================================================================================================================================
    Eine Variable horizontalMove enthält einen Wert, der aussagt, in welche Richtung der Charakter wie schnell bewegt werden soll. 
    Sie wird später durch eine Multiplikation von runSpeed erhalten und soll mit 0 initialisiert werden.
    ====================================================================================================================================
    */
    //HIER EINFÜGEN

    /*
    =======================================================================================
    Die beiden Wahrheitswerte "jump" und "crouch" sollen mit false initialisiert werden.
    Sie speichern, ob der Charakter aktuell springen oder sich ducken soll.
    =======================================================================================
    */
    //HIER EINFÜGEN
    //HIER EINFÜGEN

    void Start(){
        //Diese Funktion wird ausgeführt, wenn das Objekt, auf das sich dieses Skript bezieht, erstellt wird. Wird in diesem Fall nicht benötigt.
    }
    
    void Update(){ //Diese Funktion wird jedes Frame einmal ausgeführt.
        /*
        ====================================================================================================================
        Die Variable horizontalMove ergibt sich aus der Multiplikation von runSpeed und "Input.GetAxisRaw("Horizontal")".
        Definiere diese Gleichung.
        ====================================================================================================================
        Zur Erklärung: Der Wert von "Input.GetAxisRaw("Horizontal")" ist:
         0, wenn nichts gedrückt wird;
         1, wenn "d" oder "->" gedrückt werden;
        -1, wenn "a" oder "<-" gedrückt werden,
        */
        //HIER EINFÜGEN

        /*
        =======================================================================================================================
        Unity stellt die Funktionen "GetButtonDown" und "GetButtonUp" aus der Klasse "Input" zur Verfügung 
        (Klassenfunktionen werden aufgerufen durch "Klassenname.Funktionsname()").

        Diesen Funktionen wird der Name einer Achse aus dem Input Manager als String übergeben. 
        Der Rückgabewert ist wahr, wenn das Event stattfindet (eine entsprechende Taste ist gedrückt bzw. nicht gedrückt) 
        und falsch, wenn das Event nicht stattfindet (Taste ist nicht gedrückt bzw. gedrückt)

        Vervollständige nun die if-Entscheidung unter diesem Kommentar.
        =======================================================================================================================
        */
        if(/*HIER EINFÜGEN: wenn der (Alt)PositiveButton der Achse "Jump" gedrückt ist...*/){
            //soll die Variable "jump" auf 1 gesetzt werden...
            //HIER EINFÜGEN
        }

        /*
        ==============================================================================================================
        Wenn der unter "Crouch" gespeicherte Knopf gedrückt wird, soll die variable "crouch" auf wahr gesetzt werden.
        ==============================================================================================================
        */   
        //HIER EINFÜGEN

        /*
        ================================================================================================================================
        Ansonsten, wenn der unter "Crouch" gespeicherte Knopf wieder losgelassen wird, soll die Variable "crouch" wieder falsch werden.
        ================================================================================================================================
        */
        //HIER EINFÜGEN
        
    }

    void FixedUpdate(){ //wird ungefähr 50 mal pro Sekunde aufgerufen, hier kommt alles rein, was direkt Körper betrifft, die von Physik beeinflusst werden.
        /*
        =========================================================================================================================
        Die Funktion "Move" aus dem CharacterController2D bewegt die Spielfigur, die Übergebenen Werte sagen der Funktion, wie:
        1.  als erster Parameter wird der Wert von horizontalMove, multipliziert mit "Time.fixedDeltaTime" übergeben. 
            Letzterer Wert ist das Intervall, in dem die Physik geupdated wird. 
            Das sagt der Funktion Move, wie schnell der Charakter nach rechts oder links bewegt werden soll.
        2.  als zweiter Parameter wird die Variable "crouch" übergeben.
        3.  als dritter Parameter wird die Variable "jump" übergeben.
        =========================================================================================================================
        */
        controller.Move(/*HIER VERVOLLSTÄNDIGEN*/);
        
        /*
        ===========================================================================================
        Nachdem alle Variablen an die Funktion "Move" übergeben wurden, muss die Variable "jump"
        manuell auf false zurückgesetzt werden. Warum?
        ===========================================================================================
        */
        //HIER EINFÜGEN
    }
}
