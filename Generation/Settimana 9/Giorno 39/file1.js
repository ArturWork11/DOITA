/*
JavaScript è un linguaggio di programmazione che consente di implementare funzionalità complesse su pagine web.
è un linguaggio di scripting lato client, il che significa che il codice JavaScript viene eseguito sul computer del cliente.
è un linguaggio di programmazione ad alto livello, interpretato e orientato agli oggetti, non tipizzato e debolmente tipizzato.
Ha tutti i principi che conosciamo (variabili, cicli, condizioni, funzioni,selezione, iterazione, incapsulamento ecc.) anche se si applicano in modo diverso. */

//VARIABILI
//Le variabili in JavaScript sono dichiarate con la parola chiave var o let o const.
//const è una variabile costante il cui valore non può essere modificato.

var variabile1; //dichiarazione di una variabile
variabile1 = 5; //assegnazione di un valore

var variabile2 = 10; //dichiarazione e assegnazione di un valore

//se la dichiarazione è all'interno di un blocco di codice, la variabile è visibile solo all'interno di quel blocco, ad esempio delle graffe {}
let variabile3 = 15; 

const variabile4 = "CIAO"; //dichiarazione e assegnazione di un valore con const

//TIPI DI DATI
//JavaScript è un linguaggio di programmazione debolmente tipizzato, il che significa che non è necessario specificare il tipo di dati quando si dichiara una variabile.
//JavaScript ha i seguenti tipi di dati:
//String, Number, Boolean, Array, Object, Function, Null, Undefined

console.log(typeof variabile1); //number
console.log(variabile2 + 7); //17

// === permette di confrontare sia il valore che il tipo di dati
if (variabile3 === 15) {
    console.log("variabile3 è uguale a 15");
}
else {
    console.log("variabile3 non è uguale a 15");
}

// creazione di un array
let array = [1, 2, 3, 4, 5];
console.log(array[2]); //3

// creazione di un oggetto
let oggetto = {
    nome: "Mario",
    cognome: "Rossi",
    eta: 30
};

console.log(oggetto.nome); //Mario