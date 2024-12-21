//Una classe astratta è una classe come tutte le altre (cioè può avere campi, properties, metodi)
//ma a differenza di una classe NORMALE (classe CONCRETA) NON può essere istanziata.

//esempio: se ho le classi Studente, Docente e Dirigente e ho una classe padre che accomuna queste 3 entità
//la classe Persona potrebbe essere "ABSTRACT",cioè non utilizzabile concretamente ma solo formalmente
//Non posso fare questo: Persona p = new Persona();

//Persona p = new Studente(); 

using AbstractClass;
using System.Security.Cryptography;

// Persona p = new Persona("Giovanni","Bianchi",34); // NON può essere istanziata perchè ASTRATTA

Persona p2 = new Studente("Giovanni", "Bianchi", 34,"LFWICBGWQ");

Persona p3 = new Docente("Francesca", "Verdi", 40, 10);

Console.WriteLine(p2.ToString()); 

if (p2 is Studente)
{
    Studente s = (Studente)p2;
    s.Matricola = "WBOIWNDOIW";
}


Console.WriteLine(p2.ToString());
